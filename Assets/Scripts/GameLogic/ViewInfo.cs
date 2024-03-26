using UnityEngine;

public class ViewInfo : MonoBehaviour
{
    public static void DisplayCoinsInfo(int coinsCount)
    {
        Debug.Log("Taken coin, coins count - " + coinsCount);
    }

    public static void DisplayHealth(string name, int hitpoints)
    {
        Debug.Log($"Current health {name} - {hitpoints}");
    }

    public static void DisplayMaximumHealth(int maxHealth)
    {
        Debug.Log($"Health maximum - {maxHealth}");
    }

    public static void DisplayDeath(string name)
    {
        Debug.Log($"{name} - died");
    }
}