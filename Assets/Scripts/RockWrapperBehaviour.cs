using UnityEngine;
using System.Collections;

public class RockWrapperBehaviour : MonoBehaviour {
	private float speed;
	private Vector3 rotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Time.deltaTime * speed, 0, 0);

	}

	public void SetSpeed(float speed) {
		this.speed = speed;
	}

	public void SetRotation(Vector3 rotation) {
		this.rotation = rotation;
	}
}
