using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private List<LootSpawnPoint> _lootSpawnPoints;
    [SerializeField] private CollectableObject _collectableObjectPrefab;
    [SerializeField] private ItemPeaker _itemPeaker;

    private void OnEnable()
    {
        _itemPeaker.OnLootCollected += Collect;
    }

    private void OnDisable()
    {
        _itemPeaker.OnLootCollected -= Collect;
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var spawnPoint in _lootSpawnPoints)
            Instantiate(_collectableObjectPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    private void Collect(CollectableObject collectableObject)
    {
        Destroy(collectableObject.gameObject);
    }
}