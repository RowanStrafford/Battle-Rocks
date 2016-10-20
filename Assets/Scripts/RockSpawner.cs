using UnityEngine;
using System.Collections;

public class RockSpawner : MonoBehaviour {

    public GameObject player;
    public GameObject rock;

    public GameObject[] rocks;    

	void Start ()
    {
        Invoke("SpawnRocks", 4.0f);
        InitialRockSpawn();
	}
	
	void Update ()
    {
	
	}

    // A small amount of rocks will be randomly spawned around the map at the start.
    void InitialRockSpawn()
    {
        int numOfRocks = Random.Range(15, 25);

        for(int i = 0; i < numOfRocks; i++)
        {
            int randRock = Random.Range(0, rocks.Length);  

            float randXValue = Random.Range(-50.0f, 50.0f);     // Hard coded, sorry 
            float randYValue = Random.Range(-25.0f, 25.0f);     // will fix later. xx <3

            Vector3 rockSpawnPos = new Vector3(randXValue, randYValue, 0);
            GameObject spawnedRock = Instantiate(rocks[randRock], rockSpawnPos, Quaternion.identity) as GameObject;

            float randXScale = Random.Range(0.6f, 1.3f);
            float randYScale = Random.Range(0.6f, 1.3f);
            float randZScale = Random.Range(0.6f, 1.3f);

            spawnedRock.transform.localScale = new Vector3(randXScale, randYScale, randZScale);
            RockBehaviour rockBehaviour = spawnedRock.GetComponent<RockBehaviour>();

            float randomXRotationSpeed = Random.Range(3f, 100f);
            float randomYRotationSpeed = Random.Range(3f, 100f);
            float randomZRotationSpeed = Random.Range(3f, 100f);

            rockBehaviour.SetRotation(new Vector3(randomXRotationSpeed, randomYRotationSpeed, randomZRotationSpeed));


        }
    }

    void SpawnRocks()
    {
        //Vector3 playerPos = player.transform.position;

        float randXValue = Random.Range(-30.0f, 30.0f);
        float randYValue = Random.Range(-20.0f, 20.0f);

        Vector3 spawnLocation = new Vector3(randXValue, randYValue, 0);

        Instantiate(rock, spawnLocation, Quaternion.identity);
    }

    
}
