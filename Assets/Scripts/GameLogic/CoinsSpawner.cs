using UnityEngine;
using System.Collections.Generic;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _coinSpawnpoints;

    private int _countCoins = 5;

    private void Start()
    {
        SpawnCoins();
    }

    private void OnEnable()
    {
        Player.TakedCoin += RemoveCoin;
    }

    private void OnDisable()
    {
        Player.TakedCoin -= RemoveCoin;
    }

    private void RemoveCoin(Coin coin)
    {
        coin.Remove();
    }

    private void SpawnCoins()
    {
        List<Transform> _spawnpoints = _coinSpawnpoints;

        for (int i = 0; i < _countCoins; i++)
        {
            Transform spawnpoint = _spawnpoints[Random.Range(0, _spawnpoints.Count)];
            Instantiate(_coinPrefab, spawnpoint.position, spawnpoint.rotation);
            _spawnpoints.Remove(spawnpoint);
        }
    }
}