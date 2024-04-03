using System;
using UnityEngine;

public class PlayerTaker : MonoBehaviour
{
    public event Action<Item> TakedItem;
    public event Action TakedCoin;
    public event Action<int> TakedMedkit;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Item>(out Item item))
        {
            if (item.TryGetComponent<Coin>(out Coin coin))
                TakedCoin?.Invoke();

            if (item.TryGetComponent<Medkit>(out Medkit medkit))
                TakedMedkit?.Invoke(medkit.HealingPower);

            TakedItem?.Invoke(item);
        }
    }
}