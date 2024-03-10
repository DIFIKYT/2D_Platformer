using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const string PlayerTag = "Player";

    public static event Action ActionTakedCoin;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(PlayerTag))
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