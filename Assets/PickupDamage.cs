using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDamage : MonoBehaviour
{
    public float damage = 1;
    public float pickupTime = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = Game.Instance.scrollSpeed;

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collided = collision.gameObject;

        if (collided.GetComponent<ShipController>() != null)
        {
            collided.GetComponent<ShipController>().PickupBonusDamage(damage, pickupTime);
            Destroy(gameObject);
        }
    }
}
