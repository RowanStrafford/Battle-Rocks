using UnityEngine;
using System.Collections;

public class Beam : PhysicsObject {

	//Physics
	public float vel = 20f;

	//Class
	public float lifeTime = 10f;

	new void Start() {
		base.Start();
		//Physics
		rb.velocity += vel*transform.right;
		Destroy(gameObject, lifeTime);		
	}
	
	new void Update() {	}

	new void FixedUpdate() {
		base.FixedUpdate();
	}
}