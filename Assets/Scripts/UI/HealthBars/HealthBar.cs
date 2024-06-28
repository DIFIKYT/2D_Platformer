using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthView
{
    [SerializeField] private Slider _healthBar;

    protected override void View(float currentHealth)
    {
        _healthBar.value = currentHealth;
    }
}