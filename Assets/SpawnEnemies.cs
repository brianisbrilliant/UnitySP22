using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Transform player;
    public GameObject enemyPrefab;
    public float spawnInterval;
    public float waveInterval = 10;
    public float xRange = 5;
    public bool randomizePosition;
    public int enemiesPerWave = 10;         // after this many enemies has been killed, spawn enemies faster

    public static int currentEnemies = 0;
    public static int enemiesKilled = 0;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnFaster());
    }

    IEnumerator SpawnFaster() {
        while(true) {
            yield return new WaitForSeconds(waveInterval);
            if(spawnInterval > 0.25f) {
                spawnInterval -= 0.25f;
            }
        }
    }

    public Transform[] path1;
    public Transform[] path2;
    public Transform[] path3;
    int pathCounter = 0;

    IEnumerator SpawnEnemy() {
        while(true) {
            if(currentEnemies < enemiesPerWave) {
                GameObject clone = Instantiate(enemyPrefab, transform.position, transform.rotation);
                currentEnemies += 1;
                clone.transform.Translate(Vector3.up);      // move the enemy above the spawner's position.
                if(randomizePosition) clone.transform.Translate(Random.Range(-xRange, xRange), 0, 0);
                clone.GetComponent<MoveToPlayer>().player = this.player;

                // for maggie
                if(pathCounter == 0) {
                    clone.GetComponent<MoveToPlayer>().points = path1;
                }
                if(pathCounter == 1) {
                    clone.GetComponent<MoveToPlayer>().points = path2;
                }
                if(pathCounter == 2) {
                    clone.GetComponent<MoveToPlayer>().points = path3;
                }

                pathCounter = (pathCounter + 1) % 3;        // loops pathcounter to 0 after it gets to 2.

                // calculate interval reduction based on enemies killed.
            }
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
