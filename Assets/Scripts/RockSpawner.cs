using UnityEngine;
using System.Collections;

public class RockSpawner : MonoBehaviour {

    public GameObject player;
    public GameObject rock;

    

	void Start ()
    {
        Invoke("SpawnRocks", 4.0f);
	}
	
	void Update ()
    {
	
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
