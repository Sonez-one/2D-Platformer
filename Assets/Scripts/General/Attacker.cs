using UnityEngine;

public class Attacker : MonoBehaviour
{
    private readonly float _detectionRadius = 2f;
    private readonly int _colliderCount = 1;

    [SerializeField] private LayerMask _enemyLayer;

    private Collider2D[] _enemyColliders;

    private void Start()
    {
        _enemyColliders = new Collider2D[_colliderCount];
    }

    public void Attack(float damage)
    {
        if (Physics2D.OverlapCircleNonAlloc(transform.position, _detectionRadius, _enemyColliders, _enemyLayer) > 0)
        {
            if (_enemyColliders[0].TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);
            }
        }
    }
}