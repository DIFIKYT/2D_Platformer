using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField, Min(1)] protected float _moveSpeed = 5f;
}