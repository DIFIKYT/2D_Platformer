using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothHealthBar : HealthView
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _smoothSpeed = 100f;

    private float _targetHealth;
    private Coroutine _currentSmoothCoroutine;

    private void Awake()
    {
        _targetHealth = Health.MaxAmount;
        _healthBar.value = Health.MaxAmount;
    }

    protected override void View(float amount)
    {
        _targetHealth = amount;

        if (_currentSmoothCoroutine != null)
            StopCoroutine(_currentSmoothCoroutine);

        _currentSmoothCoroutine = StartCoroutine(SmoothUpdate());
    }

    private IEnumerator SmoothUpdate()
    {
        while (_healthBar.value != _targetHealth)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetHealth, _smoothSpeed * Time.deltaTime);
            yield return null;
        }
    }
}