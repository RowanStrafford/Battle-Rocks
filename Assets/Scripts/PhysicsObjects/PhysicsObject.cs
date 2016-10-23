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
		maxHealth = rb.mass * healthMult;
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
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;

		if (rb.velocity.magnitude > maxVel)
			rb.velocity = rb.velocity.normalized * maxVel;
	}

	void OnCollisionEnter(Collision col) {

		float collisionForce = col.relativeVelocity.magnitude;
		Debug.Log("Collision Force: "+collisionForce);

		PhysicsObject physicsObject = col.gameObject.GetComponent<PhysicsObject>();
		physicsObject.takeDamage(collisionForce);

	}

	public void takeDamage(float damage) {
		//Debug.Log(damage+" hp "+health);
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
}
