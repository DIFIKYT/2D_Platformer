using UnityEngine;

public class ViewInfo : MonoBehaviour
{
    public static void DisplayCoinsInfo(int coinsCount)
    {
        Debug.Log("Taken coin, coins count - " + coinsCount);
    }

    public static void DisplayDeath(string name)
    {
        Debug.Log($"{name} - died");
    }
}