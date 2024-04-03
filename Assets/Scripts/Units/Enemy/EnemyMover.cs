using UnityEngine;

public class EnemyMover : Mover
{
    [SerializeField] private Transform[] _points;

    private Transform _currentTarget;
    private int _currentPointIndex = 0;
    private bool _isLookRight = true;

    public bool IsLookRight => _isLookRight;

    private void Start()
    {
        if (_points.Length > 0)
            _currentTarget = _points[_currentPointIndex];
    }

    public void Move()
    {
        if (Vector2.Distance(transform.position, _currentTarget.position) < 0.01f)
            SwitchTarget();

        Vector2 newPosition = Vector2.MoveTowards(transform.position, _currentTarget.position, _moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    private void SwitchTarget()
    {
        _currentPointIndex = (_currentPointIndex + 1) % _points.Length;
        _currentTarget = _points[_currentPointIndex];

        ChangeDirection(_currentTarget);
    }

    private void ChangeDirection(Transform target)
    {
        _isLookRight = transform.position.x < target.position.x;
    }
}