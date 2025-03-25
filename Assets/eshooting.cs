using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eshooting : Enemy
{
    public float damage = 1f;

    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;


    }

    // Update is called once per frame
    protected override void Update() 
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collided = collision.gameObject;

        if (collided.GetComponent<IDamageable>() != null)
        {
            if (!collided.CompareTag("Player")) return;
            collided.GetComponent<IDamageable>().TakeDamage(damage, gameObject);
            Die();
        }
    }
}
