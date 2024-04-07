using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item _prefab;
    [SerializeField] private List<Transform> _spawnpoints;
    [SerializeField] private int _itemsCount;
    [SerializeField] private PlayerTaker _playerTaker;

    private void OnEnable()
    {
        _playerTaker.TakedItem += Remove;
    }

    private void OnDisable()
    {
        _playerTaker.TakedItem -= Remove;
    }

    private void Start()
    {
        Spawn();
    }

    private void Remove(Item item)
    {
        item.Remove();
    }

    private void Spawn()
    {
        List<Transform> spawnpoints = _spawnpoints;

        for (int i = 0; i < _itemsCount; i++)
        {
            Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Count)];
            Instantiate(_prefab, spawnpoint.position, spawnpoint.rotation);
            spawnpoints.Remove(spawnpoint);
        }
    }
}
