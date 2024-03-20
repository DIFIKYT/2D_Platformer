using System;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private int _healingPower = 25;

    public static event Action<Player, int> ActionTakedMedkit;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player)
        {
            RemoveMedkit();
            ActionTakedMedkit?.Invoke(player, _healingPower);
        }
    }

    private void RemoveMedkit()
    {
        Destroy(gameObject);
    }
}