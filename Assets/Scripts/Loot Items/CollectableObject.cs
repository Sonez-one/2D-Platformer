using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}