using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private PlayerBag _playerBag;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;

    public static event Action<Coin> TakedCoin;
    public static event Action<Medkit> TakedMedkit;

    private void Start()
    {
        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Coin>(out Coin coin))
        {
            _playerBag.TakeCoin();
            TakedCoin?.Invoke(coin);
        }

        if(collider.TryGetComponent<Medkit>(out Medkit medkit))
        {
            UseMedkit(medkit.HealingPower);
            TakedMedkit.Invoke(medkit);
        }
    }

    private void Update()
    {
        _playerMover.Move();
        _playerMover.Jump();
        _playerAnimation.AnimateMove();
    }

    private void UseMedkit(int healingPower)
    {
        RestoreHealth(healingPower);
    }
}