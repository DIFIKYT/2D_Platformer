using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothHealthBar : HealthView
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _smoothSpeed;

    private Coroutine _currentSmoothCoroutine;

    private void Awake()
    {
        _healthBar.value = _healthBar.maxValue;
    }

    protected override void View()
    {
        if (_currentSmoothCoroutine != null)
            StopCoroutine(_currentSmoothCoroutine);

        _currentSmoothCoroutine = StartCoroutine(SmoothUpdate());
    }

    private IEnumerator SmoothUpdate()
    {
        float targetValue = Health.CurrentAmount / Health.MaxAmount;

        while (_healthBar.value != targetValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, targetValue, _smoothSpeed * Time.deltaTime);
            yield return null;
        }
    }
}