using UnityEngine;
using UnityEngine.Events;

public class ItemPeaker : MonoBehaviour
{
    public event UnityAction<float> HealthRestoring;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthyFruit>(out HealthyFruit healthyFruit))
        {
            HealthRestoring?.Invoke(healthyFruit.RestoringHealthValue);

            Destroy(collision.gameObject);
        }
    }
}