using UnityEngine;
using System.Collections;

public class RockWrapperBehaviour : MonoBehaviour {
	private float speed;

	// Use this for initialization
	void Start () {
		//transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, 0);
	}
	
	void Update () {
		transform.Translate(Time.deltaTime * speed, 0, 0);//replace with force
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (transform.childCount == 0)
        {
            Destroy(gameObject);
            return;
        }

        transform.GetChild(0).transform.position = transform.position;
	}

	void FixedUpdate() {

	}

	public void SetSpeed(float speed) {
		this.speed = speed;
	}

}
