using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public float maxHealth = 1;

    public float Health { get; protected set; }

    public virtual void TakeDamage(float amount, GameObject source)
    {
        if (!source.CompareTag("Player")) return;
        Health = Health - amount;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();
    
}
