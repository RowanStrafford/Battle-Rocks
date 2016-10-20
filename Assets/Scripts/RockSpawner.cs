using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockSpawner : MonoBehaviour {

    public int initialRockNum;
    public GameObject[] rockWrappers;//Rock types to choose between
	public GameObject[] avoids;//Objects to not spawn rocks on

	public int timeBetweenWaves;
	public int waveRockNum;

	private float timer = 0;

	// Use this for initialization
	void Start () {
        createInitialRocks();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//Debug.Log(timer);
		if (timer > timeBetweenWaves) {
			spawnWave(waveRockNum);
			timer = 0;
			//Debug.Log("NEW WAVE");
		}
	}

	GameObject createRock(Vector3 spawnPos, int size = 3, int speed = 2, float rotation = 0f) {
		GameObject rockWrapper = Instantiate(rockWrappers[Random.Range(0, rockWrappers.Length)], spawnPos, Quaternion.identity) as GameObject;
		RockWrapperBehaviour rockWrapperBehaviour = rockWrapper.GetComponent<RockWrapperBehaviour>();
		GameObject rock = rockWrapper.gameObject.transform.GetChild(0).gameObject;
		RockBehaviour rockBehaviour = rock.GetComponent<RockBehaviour>();

		rockWrapperBehaviour.SetSpeed(Random.Range(0.5f, 3f));

		rock.transform.localScale = new Vector3(Random.Range(0.2f * size, 0.8f * size), Random.Range(0.2f * size, 0.8f * size), Random.Range(0.2f * size, 0.8f * size));

		rockBehaviour.SetRotation(new Vector3(Random.Range(3f, 100f), Random.Range(3f, 100f), Random.Range(3f, 100f)));

		Vector3 euler = transform.eulerAngles;
		euler.z = Random.Range(0f, 360f);
		rockWrapperBehaviour.transform.eulerAngles = euler;

		return rock;
	}

	void spawnWave(int num) {
		for (int i = 0; i < num; i++) {
			int side = Random.Range(1, 5);
			Vector3 spawnPos = new Vector3(0, 0);
			switch (side) {
				case 1:
					spawnPos.Set(Random.Range(Map.X - 100, Map.X), Random.Range(Map.Y, Map.Y + Map.H), 0);
					break;
				case 2:
					spawnPos.Set(Random.Range(Map.X, Map.X+Map.W), Random.Range(Map.Y - 100, Map.Y), 0);
					break;

				case 3:
					spawnPos.Set(Random.Range(Map.X, Map.X + 100), Random.Range(Map.Y, Map.Y + Map.H), 0);
					break;
				case 4:
					spawnPos.Set(Random.Range(Map.X, Map.X + Map.W), Random.Range(Map.Y, Map.Y + 100), 0);
					break;
			}
			createRock(spawnPos);
		}
	}

	void createInitialRocks() {
        int i = 0;

        Vector3[] avoidPositions = new Vector3[avoids.Length];

        for (i=0;i<avoids.Length;i++)
			avoidPositions[i] = avoids[i].transform.position;

        int emergencyEscape = 0;

		i = 0;
		while (i < initialRockNum) {
            Vector3 spawnPos = new Vector3(Random.Range(Map.X, Map.X+Map.W), Random.Range(Map.Y, Map.Y + Map.H), 0);
            Vector3 dist = new Vector3(0, 0);

            bool canPlace = false;
            
            for (int j = 0; j < avoids.Length; j++) {
                dist = spawnPos - avoidPositions[j];
                if (dist.magnitude < 5) {
                    //Debug.Log("skipping because too close " + i);
                    canPlace = false;
                    break;
                }
                canPlace = true;
            }

            if (canPlace == false) {
				if (emergencyEscape++ < 100) {
					continue;
				} else {
					Debug.Log("escaping infinite loop");
					return;
				}
            }
			createRock(spawnPos, Random.Range(1, 5));
			i++;
		}
    }

	

}
