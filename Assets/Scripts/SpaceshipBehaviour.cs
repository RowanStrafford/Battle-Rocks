using UnityEngine;
using System.Collections;

public class SpaceshipBehaviour : MonoBehaviour {

    public GameObject beam;
    public GameObject beamSpawnPos;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    if(Input.GetButtonDown("Fire1")) Instantiate(beam, beamSpawnPos.transform.position, transform.rotation);
    }
}
