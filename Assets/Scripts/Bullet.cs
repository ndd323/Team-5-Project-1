using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 50;
    public float damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("HIT AAAAHH");
        var collided = collision.gameObject;

        if (collided.GetComponent<IDamageable>() != null)
        {
            collided.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }
}
