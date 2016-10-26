using UnityEngine;
using System.Collections;

public class Beam : PhysicsObject {

	public float vel = 20f;
	public float lifeTime = 10f;

	new protected void Start() {
		base.Start();
		//Physics
		rb.velocity += vel*transform.right;
		Destroy(gameObject, lifeTime);		
	}

	new protected void Update() {
		base.Update();
	}

	new protected void FixedUpdate() {
		base.FixedUpdate();
	}	
}