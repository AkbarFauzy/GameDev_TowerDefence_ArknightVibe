using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnerSO Spawner;

    private void Start()
    {
        StartCoroutine(SpawnEnemy()); 
    }
    private IEnumerator SpawnEnemy() {

        for (int i = 0; i< Spawner.Instance.Count; i++)
        {
            for (int j = 0; j < Spawner.Instance[i].numberOfSpawn; j++) { 
                GameObject obj = Instantiate(Spawner.Pref, transform.position, Quaternion.identity);
                obj.transform.parent = this.transform;
                obj.GetComponent<Character>().setStats(Spawner.Instance[i].data);
                yield return new WaitForSeconds(Spawner.spawnInterval);            
            }

        }
    }
}
