using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyAnimation _enemyAnimation;

    private void Start()
    {
        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }

    private void FixedUpdate()
    {
        _enemyMover.Move();
    }

    private void Update()
    {
        _enemyAnimation.AnimateRun();
    }
}