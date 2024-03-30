using UnityEngine;

public class Medkit : Item
{
    [SerializeField, Min(25)] private int _healingPower = 25;

    public int HealingPower => _healingPower;
}