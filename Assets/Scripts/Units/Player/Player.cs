using UnityEngine;

public class Player : Character
{
    [SerializeField] private PlayerBag _playerBag;
    [SerializeField] private PlayerTaker _playerTaker;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private void OnEnable()
    {
        _playerTaker.TakedCoin += TakeCoin;
        _playerTaker.TakedMedkit += UseMedkit;
    }

    private void OnDisable()
    {
        _playerTaker.TakedCoin -= TakeCoin;
        _playerTaker.TakedMedkit -= UseMedkit;
    }

    private void Start()
    {
        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }

    private void FixedUpdate()
    {
        _playerMover.Move();
    }

    private void Update()
    {
        _playerMover.Jump();
        _playerAnimation.AnimateMove();
    }

    private void TakeCoin()
    {
        _playerBag.TakeCoin();
    }

    private void UseMedkit(int healingPower)
    {
        RestoreHealth(healingPower);
    }
}