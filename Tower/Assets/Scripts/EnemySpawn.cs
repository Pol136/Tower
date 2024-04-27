using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private SpawnerEventManager m_SpawnerEventManager;
    [SerializeField] private int spawnRate;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private int[] enemyCount;
    private int enemyType;

    [SerializeField] public bool canSpawn = true;

    public void Awake(){
        m_SpawnerEventManager.OnWaveChanged += OnWaveChanged;
    }
    private void Start()
    {
        StartCoroutine(Spawner());
        Debug.Log("0");
    }

    private IEnumerator Spawner ()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        Debug.Log("d");
        Debug.Log(canSpawn);
        for(;;){
            if (canSpawn)
            {
                Debug.Log("a");
                Random random = new Random();
                enemyType = random.Next(0, enemyPrefab.Length);
                while (enemyCount[enemyType] == 0){
                    enemyType = random.Next(0, enemyPrefab.Length);
                    Debug.Log("b");
                }
                Debug.Log("c");
                Instantiate(enemyPrefab[enemyType], transform.position, Quaternion.identity);
                enemyCount[enemyType]--;

                canSpawn = false;
                for (int i = 0; i < enemyPrefab.Length; i++){
                    if (enemyCount[i] > 0){
                        canSpawn = true;
                    }
                }
            }
            yield return wait;
        }
    }

    private void OnWaveChanged(Wave wave){
        for (int i = 0; i < wave.enemyCounts.Length; i++){
            enemyCount[i] = wave.enemyCounts[i];
        }
        canSpawn = true;
    }
}
