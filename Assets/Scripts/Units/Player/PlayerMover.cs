using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField, Min(1)] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigibody;

    private bool _isGrounded;
    private PlayerInput _playerInput;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _groundChecker = GetComponentInChildren<GroundChecker>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _groundChecker.Grounded += SetGrounded;
    }

    private void OnDisable()
    {
        _groundChecker.Grounded -= SetGrounded;
    }

    public void Move()
    {
        float moveInput = _playerInput.MoveInput;
        _rigibody.velocity = new Vector2(moveInput * _moveSpeed, _rigibody.velocity.y);
    }

    public void Jump()
    {
        if (_playerInput.IsJumpKeyDown && _isGrounded)
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, _jumpForce);
    }

    private void SetGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }
}