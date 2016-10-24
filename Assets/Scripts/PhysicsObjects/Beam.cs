using UnityEngine;
using System.Collections;

public class Beam : PhysicsObject {

	//Physics
	public float vel = 20f;
	
	//Class
	public float lifeTime = 10f;

	override protected void Start() {
		base.Start();
		maxVel = 40;
		//Physics
		rb.velocity += vel*transform.right;
		Destroy(gameObject, lifeTime);		
	}

	override protected void Update() {
		base.Update();
	}

	override protected void FixedUpdate() {
		base.FixedUpdate();
	}
}