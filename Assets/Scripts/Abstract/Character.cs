using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected Health _health;

    public void TakeDamage(int damageAmount)
    {
        _health.TakeDamage(damageAmount);

        if (_health.IsAlive == false)
        {
            ViewInfo.DisplayDeath(_name);
            Die();
            return;
        }

        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }

    public void RestoreHealth(int healingPower)
    {
        _health.RestoreHealth(healingPower);

        if (_health.IsHealthMaximum)
        {
            ViewInfo.DisplayMaximumHealth(_health.CurrentHealth);
            return;
        }

        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}