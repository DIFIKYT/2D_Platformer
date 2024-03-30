using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth { get; private set; }
    public bool IsAlive { get; private set; }
    public bool IsHealthMaximum { get; private set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if(amount <= 0) return;

        CurrentHealth -= amount;
        IsAlive = CurrentHealth > 0;
    }

    public void RestoreHealth(int amount)
    {
        if (amount <= 0) return;

        CurrentHealth = amount > (MaxHealth - CurrentHealth) ? MaxHealth : (CurrentHealth + amount);
        IsHealthMaximum = CurrentHealth >= MaxHealth;
    }
}