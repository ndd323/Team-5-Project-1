using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour, IDamageable
{
    public float moveSpeed;
    public float shootDelay = .5f;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public Transform anchor;

    private Vector3 anchorPos; // avoids allocating memory to a new Vec3 every frame
    private float nextShoot;
    private Rigidbody2D rb;

    public ShipControls Input { get; private set; }

    public float maxHealth = 5;

    public float Health { get; protected set; }

    public virtual void TakeDamage(float amount, GameObject source)
    {
        Health = Health - amount;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = Game.Input.Standard;

        anchor.Translate(Vector3.up * moveSpeed * input.MoveUp.ReadValue<float>() * Time.deltaTime);
        anchor.Translate(Vector3.down * moveSpeed * input.MoveDown.ReadValue<float>() * Time.deltaTime);
        anchor.Translate(Vector3.right * moveSpeed * input.MoveRight.ReadValue<float>() * Time.deltaTime);
        anchor.Translate(Vector3.left * moveSpeed * input.MoveLeft.ReadValue<float>() * Time.deltaTime);

        // keep us on screen
        anchorPos.Set(anchor.position.x, Mathf.Clamp(anchor.position.y, -5f, 5f), anchor.position.z);
        anchor.position = anchorPos;
        
        if (input.ShootBullet.WasPressedThisFrame() && Time.time >= nextShoot)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position + (Vector3.right * 1.3f);

            nextShoot = Time.time + shootDelay;
        }

        if (input.ShootMissile.WasPressedThisFrame())
        {
            var missile = Instantiate(missilePrefab);
            missile.transform.position = transform.position + (Vector3.right * 1.3f);
        }
    }
}
