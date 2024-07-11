using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Character _character;

    public Health Health => _health;

    protected void OnEnable()
    {
        _health.Changed += View;
        _character.Died += Destroy;
    }

    protected void OnDisable()
    {
        _health.Changed -= View;
        _character.Died -= Destroy;
    }

    protected void Start()
    {
        View();
    }

    protected abstract void View();

    protected void Destroy()
    {
        Destroy(gameObject);
    }
}