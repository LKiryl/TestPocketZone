using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _startingHealth = 3f;

    private float _currentHealth;

    private void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float GetFraction()
    {      
        return _currentHealth / _startingHealth;
    }
}
