using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPirate : Enemy
{
    public float asteroidSpawnMin = 1f;
    public float asteroidSpawnMax = 5f;
    public float moveSpeed = 5f;

    public GameObject asteroid;

    private float nextAsteroid;
    private Vector3 nextPoint = new Vector3(7.5f, 3.5f, 0f);

    protected override void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, moveSpeed * Time.deltaTime);//transform.Translate(nextPoint * moveSpeed * Time.deltaTime);

        if ((transform.position - nextPoint).sqrMagnitude <= .1f)
        {
            nextPoint.y = -nextPoint.y;
        }

        if (nextAsteroid <= Time.time)
        {
            nextAsteroid = Time.time + Random.Range(asteroidSpawnMin, asteroidSpawnMax);

            var newAsteroid = Instantiate(asteroid);
            newAsteroid.transform.position = transform.position + Vector3.left * 1f;
        }

        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        maxHealth = 10f;
        base.Start();
        nextAsteroid = Time.time + 3f;
    }
}
