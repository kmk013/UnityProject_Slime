using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoilSlime : MonoBehaviour {

    public GameObject enemy;
    public GameObject kEnemy;
    public Transform[] spawnPoints;

    private float spawnTimer = 4f;
    private float speed = 2.5f;

    private int kingNum = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        // Debug.Log(spawnTimer);
        if (Player.instance.killNum >= 10)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            kingNum += 1;

            if (kingNum <= 1)
                Instantiate(kEnemy, spawnPoints[spawnPointIndex].position, Quaternion.identity);
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, Quaternion.identity);

            spawnTimer -= speed * Time.deltaTime;

            yield return new WaitForSeconds(spawnTimer);
        }
        
    }
}
