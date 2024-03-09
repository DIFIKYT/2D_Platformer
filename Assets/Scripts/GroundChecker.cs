using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private const string GroundTag = "Ground";

    public static event Action<bool> ActionGrounded;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(GroundTag))
            ActionGrounded?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(GroundTag))
            ActionGrounded?.Invoke(false);
    }
}