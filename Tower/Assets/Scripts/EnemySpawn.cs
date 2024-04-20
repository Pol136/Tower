using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int spawnRate;

    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] public bool canSpawn = true;
    Random random = new Random();

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

            Instantiate(enemyPrefab[random.Next(0, 2)], transform.position, Quaternion.identity);
        }
    }

}
