using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxAmount;

    public event Action<float> Changed;

    public int MaxAmount => _maxAmount;
    public int CurrentAmount { get; private set; }
    public bool IsAlive => CurrentAmount > 0;
    public bool IsMaximum => CurrentAmount >= MaxAmount;

    private void Awake()
    {
        CurrentAmount = _maxAmount;
    }

    public void Reduce(int amount)
    {
        if (amount <= 0)
            return;

        CurrentAmount -= amount;

        if (IsAlive == false)
            CurrentAmount = 0;

        Changed?.Invoke(CurrentAmount);
    }

    public void Restore(int amount)
    {
        if (amount <= 0)
            return;

        CurrentAmount = Mathf.Clamp(CurrentAmount + amount, 0, MaxAmount);

        Changed?.Invoke(CurrentAmount);
    }
}