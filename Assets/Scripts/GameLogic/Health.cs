using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth { get; private set; }
    public bool IsAlive => CurrentHealth > 0;
    public bool IsHealthMaximum => CurrentHealth >= MaxHealth;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if(amount <= 0)
            return;

        CurrentHealth -= amount;

        if(IsAlive == false)
            CurrentHealth = 0;
    }

    public void RestoreHealth(int amount)
    {
        if (amount <= 0)
            return;

        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
    }
}