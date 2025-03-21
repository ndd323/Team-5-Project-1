using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCluster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var asteroid in GetComponentsInChildren<Asteroid>())
        {
            asteroid.Size = Random.Range(.5f, 5f);
            print("SIZE " + asteroid.Size);
            asteroid.transform.SetParent(null);
            //asteroid.GetComponent<Rigidbody2D>().AddTorque(Random.Range(5f, 60f));
        }

        Destroy(gameObject, .01f);
    }
}
