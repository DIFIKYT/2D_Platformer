using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    public Health Health => _health;

    protected void OnEnable()
    {
        _health.Changed += View;
    }

    protected void OnDisable()
    {
        _health.Changed -= View;
    }

    protected void Start()
    {
        View(_health.CurrentAmount);
    }

    protected abstract void View(float amount);
}