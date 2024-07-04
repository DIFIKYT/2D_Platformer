using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected Health _health;
    [SerializeField] private SmoothHealthBar _healthBar;

    public void TakeDamage(int damageAmount)
    {
        _health.Reduce(damageAmount);

        if (_health.IsAlive == false)
        {
            ViewInfo.DisplayDeath(_name);
            Die();
            return;
        }
    }

    public void RestoreHealth(int healingPower)
    {
        _health.Restore(healingPower);

        if (_health.IsMaximum)
        {
            return;
        }
    }

    private void Die()
    {
        Destroy(_healthBar.gameObject);
        Destroy(gameObject);
    }
}