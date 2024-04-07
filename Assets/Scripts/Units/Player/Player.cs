using UnityEngine;

public class Player : Character
{
    [SerializeField] private PlayerBag _playerBag;
    [SerializeField] private PlayerTaker _playerTaker;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private void OnEnable()
    {
        _playerTaker.TakedCoin += OnTakedCoin;
        _playerTaker.TakedMedkit += UseMedkit;
    }

    private void OnDisable()
    {
        _playerTaker.TakedCoin -= OnTakedCoin;
        _playerTaker.TakedMedkit -= UseMedkit;
    }

    private void Start()
    {
        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }

    private void FixedUpdate()
    {
        _playerMover.Move();
        _playerMover.Jump();
    }

    private void Update()
    {
        _playerAnimation.AnimateMove();
    }

    private void OnTakedCoin()
    {
        _playerBag.TakeCoin();
    }

    private void UseMedkit(int healingPower)
    {
        RestoreHealth(healingPower);
    }
}