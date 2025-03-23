using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : Enemy
{
    public float amplitude = 25;
    public float frequency = 1;
    public float phaseShift = 0;
    public Transform anchor;
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float shootingInterval = 2f;

    protected override void Start()
    {
        if (anchor == null) anchor = transform;
        InvokeRepeating("Shoot", 0f, shootingInterval);
    }

    protected override void Update()
    {
        float moveSpeed = Game.Instance.scrollSpeed;

        anchor.Translate(Vector3.left * (moveSpeed/2) * Time.deltaTime);
        anchor.Translate(Vector3.up * Time.deltaTime * amplitude * Mathf.Sin(Time.time * 2f * Mathf.PI * frequency + phaseShift));

        if (anchor.position.x < -20)
        {
            Destroy(gameObject);
        }
        
    }

    void Shoot() {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}