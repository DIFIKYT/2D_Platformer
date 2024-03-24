using UnityEngine;

public static class ViewInfo : object
{
    public static void DisplayChangedHealth(int amount)
    {
        Debug.Log(amount > 0 ? "������������� ��������: " + amount : "�������� �����: " + Mathf.Abs(amount));
    }

    public static void DisplayHealth(string name, int hitpoints)
    {
        Debug.Log($"������� �������� {name} - {hitpoints}");
    }

    public static void DisplayDeath(string name)
    {
        Debug.Log($"{name} ����");
    }

    public static void DisplayCoinsInfo(int coinsCount)
    {
        Debug.Log("��������� ������, ���-�� ����� - " + coinsCount);
    }
}