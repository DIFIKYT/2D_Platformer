using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private const string IsLookRightParameter = "IsLookRight";

    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed = 5f;

    private bool _isLookRight = true;
    private Transform _currentTarget;

    private void Start()
    {
        _currentTarget = _pointB;
        SetTarget(_currentTarget);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, _currentTarget.position) < 0.01f)
            SwitchTarget();

        Vector2 newPosition = Vector2.MoveTowards(transform.position, _currentTarget.position, _moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    private void SwitchTarget()
    {
        _currentTarget = (_currentTarget == _pointA) ? _pointB : _pointA;

        SetTarget(_currentTarget);
        AnimateRun();
    }

    private void SetTarget(Transform target)
    {
        if (transform.position.x < target.position.x)
            _isLookRight = true;
        else
            _isLookRight = false;
    }

    private void AnimateRun()
    {
        _animator.SetBool(IsLookRightParameter, _isLookRight);
    }
}