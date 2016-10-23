using UnityEngine;
using System.Collections;

public class Beam : PhysicsObject {

	//Physics
	static float DEFAULT_DENSITY = 15f;
	static float DEFAULT_SPEED = 20f;
	static float HEALTH_MULT = 10f;

	public float vel;
	public float minVel;
	private float lowVelTime = 0;


	//Class
	public float lifeTime = 10f;

	new void Start() {
		base.Start();
		//Physics
		rb.AddForce(transform.right * vel, ForceMode.VelocityChange);

		Destroy(gameObject, lifeTime);

		Debug.Log("Health: " + health + ", mass: " + rb.mass);
		
	}

	protected override void setVars() {
		base.setVars();
		vel = DEFAULT_SPEED;

	}

	new void Update() {
		//Debug.Log("Velocity: " + rb.velocity.magnitude);
	}

	new void FixedUpdate() {
		base.FixedUpdate();
		HandleLowVel();
	}


	void HandleLowVel() {
		vel = rb.velocity.magnitude;// velocity seems to have a delay to being set in the physics engine
		if (vel < minVel) {
			lowVelTime += Time.fixedDeltaTime;
		} else {
			lowVelTime = 0;
		}

		if (lowVelTime >= 0.05f) {
			transform.localScale = transform.localScale * 0.9f;
			if ((transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3 < 0.1f) {
				Destroy(gameObject);
				//Debug.Log("DESTROYING");
			}
		}
	}

	
}

/*
RockBehaviour rockBehaviour = col.GetComponent<RockBehaviour>();
Renderer rockRenderer = col.GetComponent<Renderer>();

//Debug.Log(col.transform.localScale.x + col.transform.localScale.y + col.transform.localScale.z / 3);


if (rockBehaviour.GetHealth() > 0)
{
	rockBehaviour.takeDamage(damage);
} else
{


1.rock is destroyed
2.rock splits into smaller rocks unless that size is less than 0.5
	1.smaller rocks combined size = 2/3 of the parent rock
	2.the rocks' size is in the usual range//change rock create to accomodate any size (float)
	3.the number of rocks spawned should depend on the dmg dealt to them

*/
