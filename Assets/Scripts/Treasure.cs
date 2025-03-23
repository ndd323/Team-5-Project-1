using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public float score_value = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collided = collision.gameObject;

        if (collided.GetComponent<ICollectable>() != null)
        {
            collided.GetComponent<ICollectable>().CollectScore(score_value, gameObject);
        }
    }
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
}
