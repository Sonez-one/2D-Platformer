using System.Collections;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private readonly float _detectionRadius = 3f;

    public bool IsEnemyInRadius { get; private set; }
    public Player Player { get; private set; }

    private void Start()
    {
        StartCoroutine(DetectEnemy());
    }

    private IEnumerator DetectEnemy()
    {
        var wait = new WaitForSeconds(1f);

        while (enabled)
        {
            Collider2D enemy = Physics2D.OverlapCircle(transform.position, _detectionRadius,_layerMask);

            if (enemy != null)
            {
                if (enemy.TryGetComponent<Player>(out Player player))
                {
                    Player = player;
                    IsEnemyInRadius = true;
                }
            }
            else
            {
                IsEnemyInRadius = false;
            }

            yield return wait;
        }
    }
}
