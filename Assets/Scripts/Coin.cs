using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action ActionTakedCoin;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
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