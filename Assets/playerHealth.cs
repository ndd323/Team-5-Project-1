using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    // Start is called before the first frame update
    void Start() {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update() {
        
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0f, 1f);  
    }
}
