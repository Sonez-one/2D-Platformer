using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private List<LootSpawnPoint> _lootSpawnPoints;
    [SerializeField] private CollectableObject _collectableObjectPrefab;
    
    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var spawnPoint in _lootSpawnPoints)
            Instantiate(_collectableObjectPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}