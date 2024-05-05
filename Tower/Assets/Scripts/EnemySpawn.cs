using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int spawnRate;

    [SerializeField] private GameObject[] enemyPrefab;

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
            Random random = new Random();
            int enemyType = random.Next(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[enemyType], transform.position, Quaternion.identity);
        }
    }

}
