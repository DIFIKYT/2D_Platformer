using UnityEngine;

public class Player : MonoBehaviour
{
    private const string AnimMoveXParameter = "AnimMoveX";
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private Rigidbody2D _rigibody;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;
    private int _coinsCount = 0;

    private void Update()
    {
        Move();
        Jump();
        AnimateMove();
    }

    private void OnEnable()
    {
        GroundChecker.ActionGrounded += SetGrounded;
        Coin.ActionTakedCoin += TakeCoin;
    }

    private void OnDisable()
    {
        GroundChecker.ActionGrounded -= SetGrounded;
        Coin.ActionTakedCoin -= TakeCoin;
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

    private void SetGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }

    private void AnimateMove()
    {
        _animator.SetFloat(AnimMoveXParameter, Input.GetAxis(HorizontalAxis));
    }

    private void TakeCoin()
    {
        _coinsCount++;

        Debug.Log("подобрана монета, кол-во монет - " + _coinsCount);
    }
}