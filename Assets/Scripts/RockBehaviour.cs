using UnityEngine;
using System.Collections;

public class RockBehaviour : MonoBehaviour {

    public float rotateSpeed;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        transform.Rotate(Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed);
	}
}
