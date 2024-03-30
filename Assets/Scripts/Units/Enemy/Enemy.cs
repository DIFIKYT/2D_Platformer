using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyMover _enemyMover;

    private void Start()
    {
        ViewInfo.DisplayHealth(_name, _health.CurrentHealth);
    }
}