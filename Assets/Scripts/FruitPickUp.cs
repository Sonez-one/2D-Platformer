using UnityEngine;

public class FruitPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            Destroy(gameObject);
        }
    }
}
