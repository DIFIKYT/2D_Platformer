using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
    }

    public void RestoreHealth(int amount)
    {
        CurrentHealth += amount;
    }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }
}