using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item _coinPrefab;
    [SerializeField] private Item _medkitPrefab;
    [SerializeField] private List<Transform> _coinSpawnpoints;
    [SerializeField] private List<Transform> _medkitSpawnpoints;

    private int _countCoins = 5;
    private int _countMiedkits = 2;

    private void Start()
    {
        SpawnItems(_countCoins, _coinSpawnpoints, _coinPrefab);
        SpawnItems(_countMiedkits, _medkitSpawnpoints, _medkitPrefab);
    }

    private void SpawnItems(int countItems, List<Transform> itemSpawnpoints, Item itemPrefab)
    {
        List<Transform> spawnpoints = itemSpawnpoints;

        for (int i = 0; i < countItems; i++)
        {
            Transform spawnpoint = spawnpoints[Random.Range(0, itemSpawnpoints.Count)];
            var item = Instantiate(itemPrefab, spawnpoint.position, spawnpoint.rotation);
            spawnpoints.Remove(spawnpoint);
        }
    }
}