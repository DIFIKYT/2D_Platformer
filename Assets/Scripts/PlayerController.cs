using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string AnimMoveXParameter = "AnimMoveX";
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Rigidbody2D _rigibody;
    [SerializeField] private Animator _animator;

    private bool _isGrounded;

    private void Update()
    {
        Move();
        Jump();
        AnimateMove();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis(HorizontalAxis);
        _rigibody.velocity = new Vector2(moveInput * _moveSpeed, _rigibody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, _jumpForce);
    }

    private void OnEnable()
    {
        GroundChecker.ActionGrounded += SetGrounded;
    }

    private void OnDisable()
    {
        GroundChecker.ActionGrounded -= SetGrounded;
    }

    private void SetGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }

    private void AnimateMove()
    {
        _animator.SetFloat(AnimMoveXParameter, Input.GetAxis(HorizontalAxis));
    }
}