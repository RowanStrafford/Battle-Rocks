using UnityEngine;
using System.Collections;
using System;

public class RockBehaviour : MonoBehaviour {

	//Physics
	public Rigidbody rb;
	public float density = 2f;

    private float health;

	void Start ()
    {
		//Physics
        float meanRockSize = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
		rb.SetDensity(density);

		health = 10 * rb.mass;
		//Debug.Log("Health: " + health + ", meanRockSize: " + meanRockSize + ", mass: " + rb.mass);
	}

	void Update() {
		//transform.Rotate(rotation * Time.deltaTime);
	}

	void FixedUpdate() {
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;
	}

    public void takeDamage(float damage)
    {
        health -= damage;
		if (health <= 0)
			Destroy(gameObject);
    }

    public float GetHealth()
    {
        return health;
    }

}
