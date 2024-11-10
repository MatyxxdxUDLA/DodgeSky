using UnityEngine;
using System;

public class AvionHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public float health, maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            OnPlayerDeath?.Invoke();
        }
    }
}
