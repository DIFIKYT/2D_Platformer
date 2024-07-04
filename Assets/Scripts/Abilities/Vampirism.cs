using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _actionTime = 6f;
    [SerializeField] private int _damageAmount = 1;

    private bool _isActive = false;

    private void Awake()
    {
        _playerInput.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _playerInput.VampirismKeyPressed += Use;
    }

    private void OnDisable()
    {
        _playerInput.VampirismKeyPressed -= Use;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isActive)
        {
            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damageAmount);
            }
        }
    }

    private void Use()
    {
        StartCoroutine(ActiveCoroutine());
    }

    private IEnumerator ActiveCoroutine()
    {
        var actionTime = new WaitForSeconds(_actionTime);

        SwitchMode(true);
        yield return actionTime;
        SwitchMode(false);
    }

    private void SwitchMode(bool isEnabled)
    {
        _isActive = isEnabled;
        _playerInput.gameObject.SetActive(isEnabled);
    }
}