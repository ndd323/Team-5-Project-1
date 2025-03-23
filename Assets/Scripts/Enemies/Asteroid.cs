using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
    public float damage = 1;
    
    public float startSize = 1;
    public float size = 1;

    public float Size
    {
        get { return size; }
        set
        {
            size = value;
            startSize = size;
            ChangeSize(size);
        }
    }

    private void ChangeSize(float newSize)
    {
        Health = Mathf.Ceil(newSize / 2);
        transform.localScale = new Vector3(newSize, newSize, 1);
    }

    protected override void Start()
    {
        Size = startSize;
    }

    protected override void Update()
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

        if (collided.GetComponent<IDamageable>() != null)
        {
            collided.GetComponent<IDamageable>().TakeDamage(damage, gameObject);
        }
    }
}
