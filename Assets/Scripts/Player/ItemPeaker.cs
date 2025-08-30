using UnityEngine;
using System;

public class ItemPeaker : MonoBehaviour
{
    public event Action<float> HealthRestoring;
    public event Action<CollectableObject> OnLootCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CollectableObject collectableObject))
        {
            if (collectableObject is HealthyFruit healthyFruit)
            {
                HealthRestoring?.Invoke(healthyFruit.RestoringHealthValue);
                OnLootCollected?.Invoke(healthyFruit);
            }
            else if (collectableObject is Coin coin)
            {
                OnLootCollected?.Invoke(coin);
            }
        }
    }
}