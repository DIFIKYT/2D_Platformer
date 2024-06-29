using UnityEngine;
using UnityEngine.UI;

public class HealthBarFollow : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if (_healthBar != null)
            _healthBar.transform.position = transform.position + _offset;
    }
}