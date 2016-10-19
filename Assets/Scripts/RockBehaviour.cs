using UnityEngine;
using System.Collections;

public class RockBehaviour : MonoBehaviour {

    public float rotateSpeed;
    private Vector3 rockRotation;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
        transform.Rotate(rockRotation * Time.deltaTime);

        //transform.Rotate(Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed);
	}

    public void SetRotation(Vector3 rotation)
    {
        rockRotation = rotation;
    }
}
