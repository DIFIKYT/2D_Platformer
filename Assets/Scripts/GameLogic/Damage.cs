using System;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damageAmount;

    public static event Action DamageReceived;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Character>(out Character character))
        {
            character.TakeDamage(_damageAmount);
        }
    }
}