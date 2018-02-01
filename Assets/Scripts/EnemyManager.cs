using UnityEngine;
using System.Collections;

/*
 * This Class Spawns Enemies in randomly chosen Spawn Locations that depend on chosen spawn locations in the inspector
 */

public class EnemyManager : MonoBehaviour {

    public GameObject enemy1prefab;
    public GameObject enemy2prefab;
    public GameObject enemy3prefab;

    public GameObject[] spawnLocations;
    int enemyCount = 0;
    float spawnRate = 1.25f;
    System.Random rnd = new System.Random();
    int spawnLocationLimit = 6;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", 5f, spawnRate);
    }
	
	// Update is called once per frame
	void Update () {
        
        
    }

    void SpawnEnemy()
    {
        int spawnLocationID = rnd.Next(0, spawnLocationLimit);
        //Debug.Log("Value of spawnLocationID =" + spawnLocationID);

        if(enemyCount > 60)
        {
            GameObject enemyClone = Instantiate(enemy3prefab, spawnLocations[spawnLocationID].transform.position, spawnLocations[spawnLocationID].transform.rotation) as GameObject;
        }
        else if(enemyCount > 30)
        {
            GameObject enemyClone = Instantiate(enemy2prefab, spawnLocations[spawnLocationID].transform.position, spawnLocations[spawnLocationID].transform.rotation) as GameObject;
        }
        else
        {
            GameObject enemyClone = Instantiate(enemy1prefab, spawnLocations[spawnLocationID].transform.position, spawnLocations[spawnLocationID].transform.rotation) as GameObject;
        }

        enemyCount++;

        if(enemyCount > 30 && enemyCount < 60)
        {
            spawnRate = .8f;
            spawnLocationLimit = 9;
        } 
        else if(enemyCount > 60)
        {
            spawnRate = .25f;
            spawnLocationLimit = 13;
        }
        //Debug.Log("Random SpawnLocation's Name = " + spawnLocations[spawnLocationID].name);
    }
}
