using UnityEngine;
using System.Collections;

public abstract class PhysicsObject : MonoBehaviour {

	protected Rigidbody rb;//accessing it publicly does not work
	protected float maxHealth;
	protected float health;
	public float healthMult;
	public float density;
	public float dmgMult;
	public float maxVel;

	// Use this for initialization
	protected void Start() {
		rb = GetComponent<Rigidbody>();
		rb.SetDensity(density);
		maxHealth = rb.mass* healthMult;
		health = maxHealth;
	}

	protected void init() {

	}

	protected virtual void setVars() {

	}

	// Update is called once per frame
	protected void Update() {

	}

	protected void FixedUpdate() {
		//Vector3 pos = transform.position;
		//pos.z = 0;
		//transform.position = pos;

		if (rb.velocity.magnitude > maxVel)
			rb.velocity = rb.velocity.normalized * maxVel;
	}

	void OnCollisionEnter(Collision col) {
		PhysicsObject physicsObject = col.gameObject.GetComponent<PhysicsObject>();
		float collisionForce = col.relativeVelocity.magnitude * rb.mass * dmgMult;
		//physicsObject.GetComponent<Rigidbody>().mass
		//Debug.Log("collisionForce: " + collisionForce); 

		physicsObject.takeDamage(collisionForce);

	}

	virtual public void takeDamage(float damage) {
		//Debug.Log("dmg: "+damage+", hp: "+health+", mass: "+rb.mass);
		health -= damage;
		if (health <= 0)
			Destroy(gameObject);
	}

	public float GetHealth() {
		return health;
	}

	public void resetHealth() {
		health = maxHealth;
	}

	virtual protected void EnforceBoundaries() {
		if (transform.position.x < Map.X || transform.position.x > Map.X + Map.W || transform.position.y < Map.Y || transform.position.y > Map.Y + Map.H)
			Destroy(gameObject, 5f);
		//transform.position = new Vector3(-90f, transform.position.y, transform.position.z);
		//if () transform.position = new Vector3(90f, transform.position.y, transform.position.z);
		//if () transform.position = new Vector3(transform.position.x, -38f, transform.position.z);
		//if () transform.position = new Vector3(transform.position.x, 38f, transform.position.z);
	}
}
