using UnityEngine;
using System.Collections;

public class RockBehaviour : MonoBehaviour {

    public float rotateSpeed;
    private Vector3 rotation;
	

	void Start ()
    {
	}
	
	void Update ()
    {
        transform.Rotate(rotation * Time.deltaTime);
		
		transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, 0);
        //transform.Rotate(Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed);
	}

    public void SetRotation(Vector3 rotation)
    {
		this.rotation = rotation;
    }

	

}
