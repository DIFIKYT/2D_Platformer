using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public static event Action<bool> Grounded;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Ground>(out Ground ground))
            Grounded?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Ground>(out Ground ground))
            Grounded?.Invoke(false);
    }
}