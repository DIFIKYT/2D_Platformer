using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damageAmount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Character>(out Character character))
            character.TakeDamage(_damageAmount);
    }
}