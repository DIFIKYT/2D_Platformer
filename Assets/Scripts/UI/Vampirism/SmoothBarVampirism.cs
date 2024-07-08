//using UnityEngine;

//public class SmoothBarVampirism : MonoBehaviour
//{

//}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBarVampirism : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private Slider _progressBar; // UI Slider для отображения бара

    private Coroutine _updateBarCoroutine = null;

    private void OnEnable()
    {
        _vampirism.OnActionStart += StartActionBar;
        _vampirism.OnCooldownStart += StartCooldownBar;
    }

    private void OnDisable()
    {
        _vampirism.OnActionStart -= StartActionBar;
        _vampirism.OnCooldownStart -= StartCooldownBar;
    }

    private void StartActionBar(float duration)
    {
        if (_updateBarCoroutine != null)
        {
            StopCoroutine(_updateBarCoroutine);
        }
        _updateBarCoroutine = StartCoroutine(UpdateBar(duration, false));
    }

    private void StartCooldownBar(float duration)
    {
        if (_updateBarCoroutine != null)
        {
            StopCoroutine(_updateBarCoroutine);
        }
        _updateBarCoroutine = StartCoroutine(UpdateBar(duration, true));
    }

    private IEnumerator UpdateBar(float duration, bool isCooldown)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            _progressBar.value = isCooldown ? (elapsed / duration) * _progressBar.maxValue : _progressBar.maxValue - (elapsed / duration) * _progressBar.maxValue;
            yield return null;
        }
    }
}