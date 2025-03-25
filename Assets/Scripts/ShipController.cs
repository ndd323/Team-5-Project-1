using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour, IDamageable, ICollectable
{
    public float moveSpeed;
    public float shootDelay = .5f;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public Transform anchor;
    public float player_score = 0;

    public Image healthBar;

    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI gameOver;

    private Vector3 anchorPos; // avoids allocating memory to a new Vec3 every frame
    private float nextShoot;
    private Rigidbody2D rb;
    private float health;

    private int bonusProjectiles = 0;
    private float bonusProjectilesEnd;
    private float bonusDamage = 0;
    private float bonusDamageEnd;

    public ShipControls Input { get; private set; }

    public float maxHealth = 10;

    public float Health { get { return health; }
        protected set
        {
            health = Mathf.Clamp(value, 0f, maxHealth);
        }
    }

    public void PickupHealth(float amount)
    {
        Health = Health + amount;
    }

    public void PickupBonusProjectiles(int amount, float time)
    {
        if (bonusProjectilesEnd > Time.time)
        {
            bonusProjectilesEnd += time;
            bonusProjectiles += amount;
        }
        else
        {
            bonusProjectilesEnd = Time.time + time;
            bonusProjectiles = amount;
        }
    }

    public void PickupBonusDamage(float amount, float time)
    {
        if (bonusDamageEnd > Time.time)
        {
            bonusDamageEnd += time;
            bonusDamage += amount;
        }
        else
        {
            bonusDamageEnd = Time.time + time;
            bonusDamage = amount;
        }
    }

    public virtual void TakeDamage(float amount, GameObject source)
    {
        Health = Health - amount;
        if (Health <= 0)
        {
            Die();
        }
    }

    public virtual void CollectScore(float value, GameObject source)
    {
        player_score += value;
        score.text = player_score.ToString();
        gameOver.text = player_score.ToString();
        Game.Instance.UpdateScore(player_score);
    }

    protected virtual void Die()
    {
        Game.Instance.endGame();

        // Move the player off screen
        transform.position = new Vector3(-100, -100, 0);

    }

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = Game.Input.Standard;

        print("SHIT " + health + " " + maxHealth + " " + health / maxHealth);
        healthBar.fillAmount = Mathf.Clamp(Health / maxHealth, 0f, 1f);

        anchor.Translate(Vector3.up * moveSpeed * input.MoveUp.ReadValue<float>() * Time.deltaTime);
        anchor.Translate(Vector3.down * moveSpeed * input.MoveDown.ReadValue<float>() * Time.deltaTime);
        anchor.Translate(Vector3.right * moveSpeed * input.MoveRight.ReadValue<float>() * Time.deltaTime);
        anchor.Translate(Vector3.left * moveSpeed * input.MoveLeft.ReadValue<float>() * Time.deltaTime);

        // keep us on screen
        anchorPos.Set(anchor.position.x, Mathf.Clamp(anchor.position.y, -5f, 5f), anchor.position.z);
        anchor.position = anchorPos;
        
        if (input.ShootBullet.WasPressedThisFrame() && Time.time >= nextShoot)
        {
            int numBullets = bonusProjectilesEnd >= Time.time ? bonusProjectiles + 1 : 1;
            float bulletDamage = bonusDamageEnd >= Time.time ? bonusDamage + 1 : 1;

            for (int i = 1; numBullets >= i; i++)
            {
                var bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position + (Vector3.right * 1.3f) + (Vector3.up * -.25f * (numBullets - 1)) + (Vector3.up * .5f * (i-1));

                bullet.GetComponent<Bullet>().damage = bulletDamage;
            }

            //var bullet = Instantiate(bulletPrefab);
            //bullet.transform.position = transform.position + (Vector3.right * 1.3f);

            nextShoot = Time.time + shootDelay;
        }

        if (input.ShootMissile.WasPressedThisFrame())
        {
            var missile = Instantiate(missilePrefab);
            missile.transform.position = transform.position + (Vector3.right * 1.3f);
        }
    }

    public void restartGame()
    {
        print("RESTARTING");
        Health = maxHealth;
        transform.position = new Vector3(-5, 0, 0);
    }
}
