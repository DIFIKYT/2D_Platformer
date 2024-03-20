using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _hitpoints;
    [SerializeField] private string _name;

    public void Change(int amount)
    {
        _hitpoints += amount;

        if (amount != 0)
            Debug.Log(amount > 0 ? "Восстановлено здоровья: " + amount : "Получено урона: " + Mathf.Abs(amount));

        if (_hitpoints <= 0)
            Die();

        DisplayHealth();
    }

    private void Start()
    {
        DisplayHealth();
    }

    private void OnEnable()
    {
        Medkit.ActionTakedMedkit += UseMedkit;
    }

    private void OnDisable()
    {
        Medkit.ActionTakedMedkit -= UseMedkit;
    }

    private void UseMedkit(Player player, int healingPower)
    {
        Player _ownerPlayer = GetComponent<Player>();

        if (_ownerPlayer == player)
            Change(healingPower);
    }

    private void Die()
    {
        Debug.Log($"{_name} убит");
        _hitpoints = 0;
        Destroy(gameObject);
    }

    private void DisplayHealth()
    {
        Debug.Log($"Текущее здоровье {_name} - {_hitpoints}");
    }
}