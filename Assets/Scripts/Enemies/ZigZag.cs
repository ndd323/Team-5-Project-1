using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : Enemy
{
    public float damage = 1;
    public float amplitude = 10;
    public float frequency = 2;
    public float phaseShift = 0;
    public Transform anchor;

    protected override void Start()
    {
        if (anchor == null) anchor = transform;
    }

    protected override void Update()
    {
        float moveSpeed = Game.Instance.scrollSpeed;

        anchor.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        anchor.Translate(Vector3.up * Time.deltaTime * amplitude * Mathf.Sin(Time.time * 2f * Mathf.PI * frequency + phaseShift));

        if (anchor.position.x < -20)
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
