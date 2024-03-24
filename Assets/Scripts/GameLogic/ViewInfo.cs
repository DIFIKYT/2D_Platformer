using UnityEngine;

public static class ViewInfo : object
{
    public static void DisplayChangedHealth(int amount)
    {
        Debug.Log(amount > 0 ? "Restored health: " + amount : "Damage received: " + Mathf.Abs(amount));
    }

    public static void DisplayHealth(string name, int hitpoints)
    {
        Debug.Log($"Current health {name} - {hitpoints}");
    }

    public static void DisplayDeath(string name)
    {
        Debug.Log($"{name} - died");
    }

    public static void DisplayCoinsInfo(int coinsCount)
    {
        Debug.Log("Taken coin, coins count - " + coinsCount);
    }
}