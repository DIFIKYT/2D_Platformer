using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    private float _moveInput;
    private bool _isJumpKeyDown;

    public float MoveInput => _moveInput;
    public bool IsJumpKeyDown => _isJumpKeyDown;

    private void Update()
    {
        _moveInput = Input.GetAxis(HorizontalAxis);
        _isJumpKeyDown = Input.GetKeyDown(KeyCode.Space);
    }
}