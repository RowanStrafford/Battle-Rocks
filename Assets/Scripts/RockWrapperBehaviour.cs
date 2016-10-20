using UnityEngine;
using System.Collections;

public class RockWrapperBehaviour : MonoBehaviour {
	private float speed;

	// Use this for initialization
	void Start () {
		//transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Time.deltaTime * speed, 0, 0);
	}

	public void SetSpeed(float speed) {
		this.speed = speed;
	}

}
