using UnityEngine;
using System.Collections;

public class RockBehaviour : MonoBehaviour {

    public float rotateSpeed;
    private Vector3 rockRotation;
	private float speed;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
        transform.Rotate(rockRotation * Time.deltaTime);
		transform.Translate(Time.deltaTime * speed, 0, 0);
        //transform.Rotate(Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed);
	}

    public void SetRotation(Vector3 rotation)
    {
        rockRotation = rotation;
    }

	public void SetSpeed(float speed) {
		this.speed = speed;
	}

}
