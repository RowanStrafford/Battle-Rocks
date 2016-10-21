using UnityEngine;
using System.Collections;

public class BeamBehaviour : MonoBehaviour {

    public float bulletSpeed;

	void Start ()
    {
        Destroy(gameObject, 10.0f);
	}
	
	void Update ()
    {
        transform.Translate(Time.deltaTime * bulletSpeed, 0, 0);//Change to force
	}
}
