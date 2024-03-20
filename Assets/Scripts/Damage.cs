using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    [SerializeField] private Collider2D _damageCollider;

    private bool _canDamage = true;
    private float _damageDelay = 1f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (_canDamage && collider.TryGetComponent<Health>(out Health health))
        {
            DealDamage(health);
            StartCoroutine(ApplyDamageDelay());
        }
    }

    private IEnumerator ApplyDamageDelay()
    {
        _canDamage = false;
        yield return new WaitForSeconds(_damageDelay);
        _canDamage = true;
    }

    private void DealDamage(Health health)
    {
        health.Change(-_damageAmount);
    }
}