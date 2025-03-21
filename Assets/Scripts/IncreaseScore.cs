using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScore : MonoBehaviour
{
    public PlayerScore p_score;
    public float score_value;
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
            p_score.score += score_value;
        }
    }
}
