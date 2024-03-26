using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected Animator _animator;
    [SerializeField, Min(1)] protected float _moveSpeed = 5f;
    [SerializeField] protected string _name;

    public void TakeDamage(int damageAmount)
    {
        if(IsAlive(_health.CurrentHealth - damageAmount) == false)
        {
            ViewInfo.DisplayDeath(_name);
            Die();
            return;
        }

        _health.TakeDamage(damageAmount);
        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }

    public void RestoreHealth(int healingPower)
    {
        if(IsHealthMaximum(_health.CurrentHealth + healingPower) == true)
        {
            ViewInfo.DisplayMaximumHealth(_health.MaxHealth);
            return;
        }

        _health.RestoreHealth(healingPower);
        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private bool IsAlive(int hitpoints)
    {
        return (hitpoints <= 0) ? false : true;
    }

    private bool IsHealthMaximum(int hitpoints)
    {
        return (hitpoints >= _health.MaxHealth) ? true : false;
    }
}