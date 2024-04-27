using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] SpawnerEventManager m_SpawnerEventManager;
    [SerializeField] EnemySpawn[] m_Spawners;
    [SerializeField] Wave[] m_Waves;
    int waveNumber = 0;
    bool needToReload = true; 
    public void Update(){
        needToReload = true;
        for (int i = 0; i < m_Spawners.Length; i++){
            if (m_Spawners[i].canSpawn){
                needToReload = false;
            }
        }
        if (needToReload){
            m_SpawnerEventManager.LoadNextWave(m_Waves[waveNumber]);
            waveNumber++;
            needToReload = false;
        }
    }
}
