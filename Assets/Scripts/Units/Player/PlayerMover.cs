using UnityEngine;

public class PlayerMover : Mover
{
    private const string HorizontalAxis = "Horizontal";

    [SerializeField, Min(1)] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigibody;

    private bool _isGrounded;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _groundChecker = GetComponentInChildren<GroundChecker>();
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
        float moveInput = Input.GetAxis(HorizontalAxis);
        _rigibody.velocity = new Vector2(moveInput * _moveSpeed, _rigibody.velocity.y);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, _jumpForce);
    }

    private void SetGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }
}