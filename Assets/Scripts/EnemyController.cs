using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    private const string IsLookRightParameter = "IsLookRight";

    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Animator _animator;

    private bool _isLookRight = true;
    private Transform _currentTarget;

    private void Start()
    {
        _currentTarget = _pointB;
        AnimateRun();
    }

    private void Update()
    {
        Move();
        AnimateRun();
    }

    private void Move()
    {
        Vector3 direction = _currentTarget.position - transform.position;
        direction.Normalize();

        transform.Translate(direction * _moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _currentTarget.position) < 0.1f)
            SwitchTarget();
    }

    private void SwitchTarget()
    {
        if (_currentTarget == _pointA)
        {
            _currentTarget = _pointB;
            _isLookRight = true;
        }
        else
        {
            _currentTarget = _pointA;
            _isLookRight = false;
        }
    }

    private void AnimateRun()
    {
        _animator.SetBool(IsLookRightParameter, _isLookRight);
    }
}