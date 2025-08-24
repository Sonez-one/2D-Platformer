using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private List<FruitSpawnPoint> _spawnPoints;
    [SerializeField] private Fruit _fruitPrefab;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            Instantiate(_fruitPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}