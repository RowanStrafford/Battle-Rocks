using UnityEngine;
using System.Collections;

public class Beam : PhysicsObject {

	//Physics
	public float vel = 20f;
    public float velMultiplier = 1;
	
	//Class
	public float lifeTime = 10f;

	new protected void Start() {
		base.Start();
		maxVel = 40;
		//Physics
		rb.velocity += vel*transform.right * velMultiplier;
		Destroy(gameObject, lifeTime);		
	}

	new protected void Update() {
		base.Update();
	}

	new protected void FixedUpdate() {
		base.FixedUpdate();
	}
}