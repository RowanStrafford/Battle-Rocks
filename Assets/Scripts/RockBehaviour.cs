using UnityEngine;
using System.Collections;

public class RockBehaviour : MonoBehaviour {

    public float rotateSpeed;
    private Vector3 rotation;
	

	void Start ()
    {
	}
	
	void Update() {
		transform.Rotate(rotation * Time.deltaTime);
	}

    public void SetRotation(Vector3 rotation)
    {
		this.rotation = rotation;
    }
}
