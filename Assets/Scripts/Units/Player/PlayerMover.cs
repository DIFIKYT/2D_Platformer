using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : Mover
{
    [SerializeField, Min(1)] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigibody;
    [SerializeField] private GroundChecker _groundChecker;

    private bool _isGrounded;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _groundChecker.Grounded += SetGrounded;
        _playerInput.JumpKeyPressed += Jump;
    }

    private void OnDisable()
    {
        _groundChecker.Grounded -= SetGrounded;
        _playerInput.JumpKeyPressed -= Jump;
    }

    public void Move()
    {
        float moveInput = _playerInput.MoveInput;
        _rigibody.velocity = new Vector2(moveInput * _moveSpeed, _rigibody.velocity.y);
    }

    public void Jump()
    {
        if (_isGrounded)
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, _jumpForce);
    }

    private void SetGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }
}