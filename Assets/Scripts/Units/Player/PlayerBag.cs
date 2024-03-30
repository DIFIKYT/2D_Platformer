using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    private int _coinsCount;

    public void TakeCoin()
    {
        _coinsCount++;
        ViewCoins();
    }

    private void ViewCoins()
    {
        ViewInfo.DisplayCoinsInfo(_coinsCount);
    }
}