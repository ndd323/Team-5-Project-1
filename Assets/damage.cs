using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public playerHealth pHealth;
    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("ship hit");
        if (other.gameObject.CompareTag("Player")) {
            pHealth.health -= dmg;
        }
    }
}
