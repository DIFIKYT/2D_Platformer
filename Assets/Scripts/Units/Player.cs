using UnityEngine;

public class Player : Character
{
    private const string AnimMoveXParameter = "AnimMoveX";
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private Rigidbody2D _rigibody;
    [SerializeField, Min(1)] private float _jumpForce;

    private int _coinsCount = 0;
    private bool _isGrounded;

    private void Update()
    {
        Move();
        Jump();
        AnimateMove();
    }

    private void Start()
    {
        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }

    private void OnEnable()
    {
        GroundChecker.Grounded += SetGrounded;
        Coin.TakedCoin += TakeCoin;
        Medkit.TakedMedkit += UseMedkit;
    }

    private void OnDisable()
    {
        GroundChecker.Grounded -= SetGrounded;
        Coin.TakedCoin -= TakeCoin;
        Medkit.TakedMedkit -= UseMedkit;
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
        ViewInfo.DisplayCoinsInfo(_coinsCount);
    }

    private void UseMedkit(int healingPower)
    {
        RestoreHealth(healingPower);
    }
}