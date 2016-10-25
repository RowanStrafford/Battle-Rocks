using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockSpawner : MonoBehaviour {

    public int initialRockNum;
    public GameObject[] rocks;//Rock types to choose between
	public GameObject[] avoids;//Objects to not spawn rocks on

	public int timeBetweenWaves;
	public int waveRockNum;

	private float timer = 0;

	// Use this for initialization
	void Start () {
		Map.rocks = rocks;
		createInitialRocks();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > timeBetweenWaves) {
			spawnWave(waveRockNum);
			timer = 0;
		}
	}

	GameObject createRock(Vector3 spawnPos, int size = 3, float speed = 2, float rotation = -1f) {
		speed = Random.Range(1f * speed, 2.5f * speed);

		if (rotation == -1f)
			rotation = Random.Range(0, 360f);

		GameObject rock = Instantiate(rocks[Random.Range(0, rocks.Length)], spawnPos, Quaternion.identity) as GameObject;
		Rigidbody rb = rock.GetComponent<Rigidbody>();

		//Size
		rock.transform.localScale = new Vector3(Random.Range(0.2f * size, 1f * size), Random.Range(0.2f * size, 1f * size), Random.Range(0.2f * size, 1f * size));
			rock.transform.localScale = rock.transform.localScale * 5;

		//Direction
		rock.transform.eulerAngles = new Vector3(0, 0, rotation);

		//Forces
		rb.AddTorque(new Vector3(Random.Range(3f, 100f), Random.Range(3f, 100f), Random.Range(3f, 100f)));
		rb.AddForce(rock.transform.right*speed, ForceMode.VelocityChange);
		

		return rock;
	}

	void spawnWave(int num) {
		for (int i = 0; i < num; i++) {
			int side = Random.Range(1, 5);
			Vector3 spawnPos = new Vector3(0, 0);
			float rotation = 0f;
			switch (side) {
				case 1://LEFT
					spawnPos.Set(Random.Range(Map.X - 50 - 10, Map.X - 10), Random.Range(Map.Y + Map.H, Map.Y), 0);
					rotation = Random.Range(0f - 20f, 0f + 20f);
					break;
				case 2://BOT
					spawnPos.Set(Random.Range(Map.X, Map.X + Map.W), Random.Range(Map.Y - 50 - 10, Map.Y - 10), 0);
					rotation = Random.Range(90f - 20f, 90f + 20f);
					break;
				case 3://RIGHT
					spawnPos.Set(Random.Range(Map.X + Map.W + 10, Map.X + Map.W + 50 + 10), Random.Range(Map.Y, Map.Y + Map.H), 0);
					rotation = Random.Range(180f - 20f, 180f + 20f);
					break;
				case 4://TOP
					spawnPos.Set(Random.Range(Map.X, Map.X + Map.W), Random.Range(Map.Y + Map.H + 10, Map.Y + Map.H + 50 + 10), 0);
					rotation = Random.Range(270f - 20f, 270f + 20f);
					break;
			}
			createRock(spawnPos, Random.Range(1, 5), Random.Range(2, 5), rotation);
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
