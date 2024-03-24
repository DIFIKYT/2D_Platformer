using System;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public static event Action ActionMedkitCoin;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            RemoveMedkit();
            ActionMedkitCoin?.Invoke();
        }
    }

    private void RemoveMedkit()
    {
        Destroy(gameObject);
    }
}