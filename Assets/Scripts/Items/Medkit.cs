using System;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField, Min(25)] private int _healingPower = 25;

    public static event Action<int> TakedMedkit;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            RemoveMedkit();
            TakedMedkit?.Invoke(_healingPower);
        }
    }

    private void RemoveMedkit()
    {
        Destroy(gameObject);
    }
}