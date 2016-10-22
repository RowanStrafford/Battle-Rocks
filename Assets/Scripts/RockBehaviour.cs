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
        float meanRockSize = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
        health = 10 * meanRockSize;
		//Debug.Log(rb.mass);
		rb.SetDensity(density);
		//Debug.Log(rb.mass);
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
    }

    public float GetHealth()
    {
        return health;
    }

}
