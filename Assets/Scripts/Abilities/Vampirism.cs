//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Vampirism : MonoBehaviour
//{
//    [SerializeField] private Player _player;
//    [SerializeField] private PlayerInput _playerInput;
//    [SerializeField] private CircleCollider2D _circleCollider;
//    [SerializeField] private SpriteRenderer _spriteRenderer;
//    [SerializeField] private int _powerAmount;
//    [SerializeField] private float _cooldownTime;
//    [SerializeField] private float _actionTime;
//    [SerializeField] private float _damageInterval;

//    private bool _isCooldown = false;
//    private bool _isActive = false;
//    private List<Enemy> _enemiesInArea = new();
//    private Coroutine _pumpingHealthCoroutine = null;

//    private void Awake()
//    {
//        _spriteRenderer.enabled = _isActive;
//        _circleCollider.enabled = _isActive;
//    }

//    private void OnEnable()
//    {
//        _playerInput.VampirismKeyPressed += Use;
//    }

//    private void OnDisable()
//    {
//        _playerInput.VampirismKeyPressed -= Use;
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
//            _enemiesInArea.Add(enemy);
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
//            _enemiesInArea.Remove(enemy);
//    }

//    private void Use()
//    {
//        StartCoroutine(ActiveCoroutine());
//    }

//    private IEnumerator CooldownCoroutine()
//    {
//        _isCooldown = true;
//        yield return new WaitForSeconds(_cooldownTime);
//        _isCooldown = false;
//    }

//    private IEnumerator ActiveCoroutine()
//    {
//        var actionTime = new WaitForSeconds(_actionTime);

//        SwitchMode(true);
//        yield return actionTime;
//        SwitchMode(false);

//        StartCoroutine(CooldownCoroutine());
//    }

//    private IEnumerator PumpingHealthCoroutine()
//    {
//        var damageInterval = new WaitForSeconds(_damageInterval);

//        while (_isActive)
//        {
//            foreach (Enemy enemy in _enemiesInArea)
//            {
//                enemy.TakeDamage(_powerAmount);
//                _player.RestoreHealth(_powerAmount);
//            }

//            yield return damageInterval;
//        }
//    }

//    private void SwitchMode(bool isEnabled)
//    {
//        _isActive = isEnabled;
//        _spriteRenderer.enabled = isEnabled;
//        _circleCollider.enabled = isEnabled;

//        if (isEnabled)
//        {
//            _pumpingHealthCoroutine = StartCoroutine(PumpingHealthCoroutine());
//        }
//        else
//        {
//            if (_pumpingHealthCoroutine != null)
//            {
//                StopCoroutine(_pumpingHealthCoroutine);
//                _pumpingHealthCoroutine = null;
//            }
//        }
//    }
//}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    // Существующие поля и свойства
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private int _powerAmount;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _actionTime;
    [SerializeField] private float _damageInterval;

    private bool _isCooldown = false;
    private bool _isActive = false;
    private List<Enemy> _enemiesInArea = new();
    private Coroutine _pumpingHealthCoroutine = null;

    // Свойства для получения времени перезарядки и действия
    public float CooldownTime => _cooldownTime;
    public float ActionTime => _actionTime;
    public bool IsActive => _isActive;
    public bool IsCooldown => _isCooldown;

    // События для уведомления о состоянии способности
    public event Action<float> OnActionStart;
    public event Action<float> OnCooldownStart;

    // Существующие методы

    private void Awake()
    {
        _spriteRenderer.enabled = _isActive;
        _circleCollider.enabled = _isActive;
    }

    private void OnEnable()
    {
        _playerInput.VampirismKeyPressed += Use;
    }

    private void OnDisable()
    {
        _playerInput.VampirismKeyPressed -= Use;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemiesInArea.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _enemiesInArea.Remove(enemy);
    }

    private void Use()
    {
        if (!_isCooldown)
            StartCoroutine(ActiveCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        _isCooldown = true;
        OnCooldownStart?.Invoke(_cooldownTime);
        yield return new WaitForSeconds(_cooldownTime);
        _isCooldown = false;
    }

    private IEnumerator ActiveCoroutine()
    {
        var actionTime = new WaitForSeconds(_actionTime);

        OnActionStart?.Invoke(_actionTime);
        SwitchMode(true);
        yield return actionTime;
        SwitchMode(false);

        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator PumpingHealthCoroutine()
    {
        var damageInterval = new WaitForSeconds(_damageInterval);

        while (_isActive)
        {
            foreach (Enemy enemy in _enemiesInArea)
            {
                enemy.TakeDamage(_powerAmount);
                _player.RestoreHealth(_powerAmount);
            }

            yield return damageInterval;
        }
    }

    private void SwitchMode(bool isEnabled)
    {
        _isActive = isEnabled;
        _spriteRenderer.enabled = isEnabled;
        _circleCollider.enabled = isEnabled;

        if (isEnabled)
        {
            _pumpingHealthCoroutine = StartCoroutine(PumpingHealthCoroutine());
        }
        else
        {
            if (_pumpingHealthCoroutine != null)
            {
                StopCoroutine(_pumpingHealthCoroutine);
                _pumpingHealthCoroutine = null;
            }
        }
    }
}