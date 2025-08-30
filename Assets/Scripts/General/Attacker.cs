using UnityEngine;

public class Attacker : MonoBehaviour
{
    private readonly float _detectionRadius = 2f;

    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _enemyLayer;

    private Collider2D[] _enemyColliders;

    private void Start()
    {
        _enemyColliders = new Collider2D[1];
    }

    public void Attack()
    {
        if (Physics2D.OverlapCircleNonAlloc(transform.position, _detectionRadius, _enemyColliders, _enemyLayer) > 0)
        {
            if (_enemyColliders[0].TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage);
            }
        }
    }
}