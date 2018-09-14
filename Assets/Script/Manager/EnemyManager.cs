using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnPoints;

    // Use this for initialization
    void Start()
    {
       StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, Quaternion.identity);

            yield return new WaitForSeconds(3); 
        }
        
    }
}
