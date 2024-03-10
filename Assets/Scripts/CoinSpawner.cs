using UnityEngine;
using System.Collections.Generic;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _coinSpawnpoints;

    private int _countCoins = 5;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        List<Transform> coinSpawnpoints = _coinSpawnpoints;

        for(int i = 0;  i < _countCoins; i++)
        {
            Transform spawnpoint = coinSpawnpoints[Random.Range(0, _coinSpawnpoints.Count)];
            Coin coin = Instantiate(_coinPrefab, spawnpoint.position, spawnpoint.rotation);
            coinSpawnpoints.Remove(spawnpoint);
        }
    }
}