using UnityEngine;
using System.Collections.Generic;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField] private Medkit _medkitPrefab;
    [SerializeField] private List<Transform> _medkitSpawnpoints;

    private int _countMedkits = 2;

    private void Start()
    {
        SpawnMidkits();
    }

    private void SpawnMidkits()
    {
        List<Transform> medkitSpawnpoints = _medkitSpawnpoints;

        for (int i = 0; i < _countMedkits; i++)
        {
            Transform spawnpoint = medkitSpawnpoints[Random.Range(0, _medkitSpawnpoints.Count)];
            Medkit medkit = Instantiate(_medkitPrefab, spawnpoint.position, spawnpoint.rotation);
            medkitSpawnpoints.Remove(spawnpoint);
        }
    }
}