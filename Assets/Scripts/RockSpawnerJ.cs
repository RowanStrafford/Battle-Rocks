using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockSpawnerJ : MonoBehaviour {

    public int initialRockNum;
    public GameObject[] rocks;//Rock types to choose between
	public GameObject[] avoids;//Objects to not spawn rocks on

	// Use this for initialization
	void Start () {
        createInitialRocks();
	}

	// Update is called once per frame
	void Update () {
	
	}

    void createInitialRocks() {
        int i = 0;

        Vector3[] avoidPositions = new Vector3[avoids.Length];

        for (i=0;i<avoids.Length;i++)
			avoidPositions[i] = avoids[i].transform.position;

        int emergencyEscape = 0;

		i = 0;
		while (i < initialRockNum) {
            Vector3 spawnPos = new Vector3(Random.Range(Map.X, Map.X+Map.W), Random.Range(Map.Y, Map.Y + Map.H));

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

			if (createRock(Instantiate(rocks[Random.Range(0, rocks.Length)], spawnPos, Quaternion.identity) as GameObject))
				i++;
			else
				i = 100;
        }
    }


	bool createRock(GameObject rock) {
		rock.transform.localScale = new Vector3(Random.Range(0.6f, 2f), Random.Range(0.6f, 2f), Random.Range(0.6f, 2f));

		


		RockBehaviour rockBehaviour = rock.GetComponent<RockBehaviour>();
		if (rockBehaviour == null) {
			Debug.Log("rockBehaviour=null");
			Debug.Log("Exited the Application");
			Application.Quit();
			return false;
		} else {
			rockBehaviour.SetRotation(new Vector3(Random.Range(3f, 100f), Random.Range(3f, 100f), Random.Range(3f, 100f)));
			rockBehaviour.SetSpeed(Random.Range(0.5f, 3f));
			return true;
		}
		
	}


}
