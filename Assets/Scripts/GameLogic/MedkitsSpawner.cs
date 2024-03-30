using UnityEngine;
using System.Collections.Generic;

public class MedkitsSpawner : MonoBehaviour
{
    [SerializeField] private Medkit _medkitPrefab;
    [SerializeField] private List<Transform> _medkitSpawnpoints;

    private int _countMedkits = 2;

    private void Start()
    {
        SpawnMedkits();
    }

    private void OnEnable()
    {
        Player.TakedMedkit += RemoveMedkit;
    }

    private void OnDisable()
    {
        Player.TakedMedkit -= RemoveMedkit;
    }

    private void RemoveMedkit(Medkit medkit)
    {
        medkit.Remove();
    }

    private void SpawnMedkits()
    {
        List<Transform> _spawnpoints = _medkitSpawnpoints;

        for (int i = 0; i < _countMedkits; i++)
        {
            Transform spawnpoint = _spawnpoints[Random.Range(0, _spawnpoints.Count)];
            Instantiate(_medkitPrefab, spawnpoint.position, spawnpoint.rotation);
            _spawnpoints.Remove(spawnpoint);
        }
    }
}