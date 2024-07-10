using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBarVampirism : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private float _smoothSpeed;

    private Coroutine _activeCoroutine = null;

    private void OnEnable()
    {
        _vampirism.VampirismActivated += Activate;
        _vampirism.CooldownStarted += Activate;
    }

    private void OnDisable()
    {
        _vampirism.VampirismActivated -= Activate;
        _vampirism.CooldownStarted -= Activate;
    }

    private void Activate(bool isActive)
    {
        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);

        _activeCoroutine = StartCoroutine(UpdateBar(isActive));
    }

    private IEnumerator UpdateBar(bool isActive)
    {
        float value = isActive ? _progressBar.minValue : _progressBar.maxValue;

        while (_progressBar.value != value)
        {
            _progressBar.value = Mathf.MoveTowards(_progressBar.value, value, _smoothSpeed * Time.deltaTime);
            yield return null;
        }
    }
}