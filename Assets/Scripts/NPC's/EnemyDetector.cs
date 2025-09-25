using System.Collections;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private readonly float _detectionRadius = 2f;
    private readonly float _delay = 1f;
    private readonly int _colliderCount = 1;

    [SerializeField] private LayerMask _layerMask;

    private Collider2D[] _enemyColliders;

    public bool IsEnemyInRadius { get; private set; }
    public Player Player { get; private set; }

    private void Start()
    {
        _enemyColliders = new Collider2D[_colliderCount];

        StartCoroutine(DetectEnemy());
    }

    private IEnumerator DetectEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            int foundEnemy = Physics2D.OverlapCircleNonAlloc(transform.position, _detectionRadius, _enemyColliders, _layerMask);

            if (foundEnemy != 0)
            {
                for (int i = 0; i < _enemyColliders.Length; i++)
                {
                    if (_enemyColliders[i].TryGetComponent(out Player player))
                    {
                        Player = player;
                        IsEnemyInRadius = true;
                    }
                    else
                    {
                        IsEnemyInRadius = false;
                    }
                }
            }

            yield return wait;
        }
    }
}