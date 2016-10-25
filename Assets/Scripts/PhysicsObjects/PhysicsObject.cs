using UnityEngine;
using System.Collections;

public abstract class PhysicsObject : MonoBehaviour {

	protected Rigidbody rb;//accessing it publicly does not work
	protected float maxHealth;
	protected float health;
	public float healthMult;
	public float density;
	public float dmgMult = 1;
	public float maxVel = 20;

	// Use this for initialization
	virtual protected void Start() {
		rb = GetComponent<Rigidbody>();
		rb.SetDensity(density);
		maxHealth = rb.mass* healthMult;
		health = maxHealth;
	}

	// Update is called once per frame
	virtual protected void Update() {
		EnforceBoundaries();
	}

	virtual protected void FixedUpdate() {
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;
		//sometimes vector forward pos is off center, fix later
		//Debug.Log(rb.velocity.magnitude);
		if (rb.velocity.magnitude > maxVel)
			rb.velocity = rb.velocity.normalized * maxVel;
	}

	virtual protected void OnCollisionEnter(Collision col) {
		PhysicsObject physicsObject = col.gameObject.GetComponent<PhysicsObject>();
		float collisionForce = col.relativeVelocity.magnitude * rb.mass;

		physicsObject.takeDamage(collisionForce*dmgMult);
	}

	virtual public void takeDamage(float damage) {
		health -= damage;
		if (health <= 0)
			Die(damage);
	}

	virtual protected void Die(float damage) {
		Destroy(gameObject);
	}

	public float GetHealth() {
		return health;
	}

	public void ResetHealth() {
		health = maxHealth;
	}

	virtual protected void EnforceBoundaries() {
		if (transform.position.x < Map.X || transform.position.x > Map.X + Map.W || transform.position.y < Map.Y || transform.position.y > Map.Y + Map.H)
			Destroy(gameObject, 1f);
	}
}
