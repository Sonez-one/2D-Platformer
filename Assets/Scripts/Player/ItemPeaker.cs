using UnityEngine;

public class ItemPeaker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Fruit>(out _))
            Destroy(collision.gameObject);
    }
}