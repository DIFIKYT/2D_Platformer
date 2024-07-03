using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    public event Action JumpKeyPressed;
    public event Action VampirismKeyPressed;

    private float _moveInput;
    private bool _isJumpKeyDown;
    private bool _isVampirismKeyDown;

    public float MoveInput => _moveInput;
    public bool IsJumpKeyDown => _isJumpKeyDown;
    public bool IsVampirismKeyDown => _isVampirismKeyDown;

    private void Update()
    {
        if (IsJumpKeyDown)
            JumpKeyPressed?.Invoke();

        if (IsVampirismKeyDown)
            VampirismKeyPressed?.Invoke();

        _moveInput = Input.GetAxis(HorizontalAxis);
        _isJumpKeyDown = Input.GetKeyDown(KeyCode.Space);
        _isVampirismKeyDown = Input.GetKey(KeyCode.Q);
    }
}