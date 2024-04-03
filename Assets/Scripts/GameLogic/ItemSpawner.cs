using UnityEngine;
using System.Collections.Generic;
using System;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private List<Transform> _itemSpawnpoints;
    [SerializeField] private int _itemsCount;

    public static event Action TakedCoin;
    public static event Action<int> TakedMedkit;

    private PlayerTaker _playerTaker;

    private void Awake()
    {
        _playerTaker = FindAnyObjectByType<PlayerTaker>();
    }

    private void OnEnable()
    {
        _playerTaker.TakedItem += RemoveItem;
    }

    private void OnDisable()
    {
        _playerTaker.TakedItem -= RemoveItem;
    }

    private void Start()
    {
        SpawnItems();
    }

    private void RemoveItem(Item item)
    {
        item.Remove();
    }

    private void SpawnItems()
    {
        List<Transform> _spawnpoints = _itemSpawnpoints;

        for (int i = 0; i < _itemsCount; i++)
        {
            Transform spawnpoint = _spawnpoints[UnityEngine.Random.Range(0, _spawnpoints.Count)];
            Instantiate(_itemPrefab, spawnpoint.position, spawnpoint.rotation);
            _spawnpoints.Remove(spawnpoint);
        }
    }
}
