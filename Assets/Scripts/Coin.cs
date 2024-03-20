using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action ActionTakedCoin;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            RemoveCoin();
            ActionTakedCoin?.Invoke();
        }
    }

    private void RemoveCoin()
    {
        Destroy(gameObject);
    }
}