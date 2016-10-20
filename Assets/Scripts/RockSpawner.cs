using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockSpawner : MonoBehaviour {

    public int initialRockNum;
    public GameObject[] rockWrappers;//Rock types to choose between
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

			if (createRock(Instantiate(rockWrappers[Random.Range(0, rockWrappers.Length)], spawnPos, Quaternion.identity) as GameObject))
				i++;
			else
				break;
        }
    }

	bool createRock(GameObject rockWrapper) {
		GameObject rock = rockWrapper.gameObject.transform.GetChild(0).gameObject;

		rock.transform.localScale = new Vector3(Random.Range(0.6f, 2.5f), Random.Range(0.6f, 2.5f), Random.Range(0.6f, 2.5f));
		
		RockBehaviour rockBehaviour = rock.GetComponent<RockBehaviour>();
		if (rockBehaviour == null) {
			Debug.Log("rockBehaviour=null");
			Debug.Log("Exited the Application");
			Application.Quit();
			return false;
		} else {
			rockBehaviour.SetRotation(new Vector3(Random.Range(3f, 100f), Random.Range(3f, 100f), Random.Range(3f, 100f)));
			RockWrapperBehaviour rockWrapperBehaviour = rockWrapper.GetComponent<RockWrapperBehaviour>();
			rockWrapperBehaviour.SetSpeed(Random.Range(0.5f, 3f));
			Vector3 euler = transform.eulerAngles;
			euler.z = Random.Range(0f, 360f);
			rockWrapperBehaviour.transform.eulerAngles = euler;
			return true;
		}
	}
}
