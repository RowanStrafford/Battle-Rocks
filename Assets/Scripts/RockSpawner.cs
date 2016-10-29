using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RockSpawner : MonoBehaviour {

    public int initialRockNum;
    public GameObject[] rocks;//Rock types to choose between
	public GameObject[] avoids;//Objects to not spawn rocks on

	public int timeBetweenWaves;
	public int waveRockNum;

	private float timer = 0;
	public int score = 0;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		Map.rocks = rocks;
		createInitialRocks();

		scoreText.text = "Score: " + score.ToString();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > timeBetweenWaves) {
			spawnWave(waveRockNum);
			timer = 0;
			score += 10;
			scoreText.text = "Score: " + score.ToString();
		}
	}

	GameObject createRock(Vector3 spawnPos, float size = 3, float speed = 2, float rotation = -1f) {
		speed = Random.Range(0.8f * speed, 2.5f * speed);

		if (rotation == -1f)
			rotation = Random.Range(0, 360f);

		GameObject rock = Instantiate(rocks[Random.Range(0, rocks.Length)], spawnPos, Quaternion.identity) as GameObject;
		Rigidbody rb = rock.GetComponent<Rigidbody>();

		//Size
		rock.transform.localScale = new Vector3(Random.Range(0.2f * size, 1f * size), Random.Range(0.2f * size, 1f * size), Random.Range(0.2f * size, 1f * size));
		if (Random.Range(0, 10f) > 9.98)
			rock.transform.localScale = rock.transform.localScale * 3;

		//Direction
		rock.transform.eulerAngles = new Vector3(0, 0, rotation);

		//Forces
		rb.AddTorque(new Vector3(Random.Range(1f, 100f + wave), Random.Range(1f, 100f + wave), Random.Range(1f, 100f + wave)));
		rb.AddForce(rock.transform.right * speed, ForceMode.VelocityChange);
		

		return rock;
	}
	float wave = 1;
	void spawnWave(int num) {
		for (int i = 0; i < num; i++) {
			int side = Random.Range(1, 5);
			Vector3 spawnPos = new Vector3(0, 0);
			float rotation = 0f;
			switch (side) {
				case 1://LEFT
					spawnPos.Set(Random.Range(Map.X - 30 - 10, Map.X - 10), Random.Range(Map.Y + Map.H, Map.Y), 0);
					rotation = Random.Range(0f - 20f, 0f + 20f);
					break;
				case 2://BOT
					spawnPos.Set(Random.Range(Map.X, Map.X + Map.W), Random.Range(Map.Y - 30 - 10, Map.Y - 10), 0);
					rotation = Random.Range(90f - 20f, 90f + 20f);
					break;
				case 3://RIGHT
					spawnPos.Set(Random.Range(Map.X + Map.W + 10, Map.X + Map.W + 30 + 10), Random.Range(Map.Y, Map.Y + Map.H), 0);
					rotation = Random.Range(180f - 20f, 180f + 20f);
					break;
				case 4://TOP
					spawnPos.Set(Random.Range(Map.X, Map.X + Map.W), Random.Range(Map.Y + Map.H + 10, Map.Y + Map.H + 30 + 10), 0);
					rotation = Random.Range(270f - 20f, 270f + 20f);
					break;
			}
			createRock(spawnPos, Random.Range(3, 4+0.4f*wave), Random.Range(0.5f, 1.5f+0.2f * wave), rotation);
		}
		wave+=1.2f;
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
                if (dist.magnitude < 15) {
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
			createRock(spawnPos, Random.Range(1, 5), 1);
			i++;
		}
    }

	

}
