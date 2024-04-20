using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int spawnRate;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] public bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner ()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }

}
