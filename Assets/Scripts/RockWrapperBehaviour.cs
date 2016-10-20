using UnityEngine;
using System.Collections;

public class RockWrapperBehaviour : MonoBehaviour {
	private float speed;

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

}
