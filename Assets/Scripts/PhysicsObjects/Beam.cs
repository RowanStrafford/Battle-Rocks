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
