using UnityEngine;
using System.Collections;
using System;

public class RockBehaviour : MonoBehaviour {

    public float rotateSpeed;
    private Vector3 rotation;
	public Rigidbody rb;
	public float speed;

    private float health;	

	void Start ()
    {
        float meanRockSize = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
        health = 10 * meanRockSize;
	}
	
	void Update() {
		//transform.Rotate(rotation * Time.deltaTime);
	}

	void FixedUpdate() {
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;
	}

    public void SetRotation(Vector3 rotation)
    {
		this.rotation = rotation;
		rb.AddTorque(rotation);
	}

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

	public float GetSpeed() {
		return speed;
	}

	public void SetSpeed(float speed) {
		this.speed = speed;
	}

	public void SetDirection(Vector3 euler, float speed) {
		transform.eulerAngles = euler;
		rb.AddForce(transform.right*100*speed);
	}
}
