using System.Collections;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private Attacker _attacker;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        var wait = new WaitForSeconds(1f);

        while (enabled)
        {
            _attacker.Attack();

            yield return wait;
        }
    }
}