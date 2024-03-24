using UnityEngine;

public static class ViewInfo : object
{
    public static void DisplayChangedHealth(int amount)
    {
        Debug.Log(amount > 0 ? "Восстановлено здоровья: " + amount : "Получено урона: " + Mathf.Abs(amount));
    }

    public static void DisplayHealth(string name, int hitpoints)
    {
        Debug.Log($"Текущее здоровье {name} - {hitpoints}");
    }

    public static void DisplayDeath(string name)
    {
        Debug.Log($"{name} убит");
    }

    public static void DisplayCoinsInfo(int coinsCount)
    {
        Debug.Log("подобрана монета, кол-во монет - " + coinsCount);
    }
}