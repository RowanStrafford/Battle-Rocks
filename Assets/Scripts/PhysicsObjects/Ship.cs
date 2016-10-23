using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ship : PhysicsObject {

	public GameObject cameraObject;

	public float force = 3.0f;


	public GameObject beam;
	public GameObject beamSpawnPos;


	//public Scrollbar healthBar;

	// Use this for initialization
	new void Start () {
		base.Start();
		UpdateHealthBar();
		Debug.Log("Health: " + health + ", mass: " + rb.mass);
	}

	// Update is called once per frame
	new void Update () {
		setRotation();
		if (Input.GetButtonDown("Fire1"))//why does this need to be in update
			fire();
	}

	new void FixedUpdate() {
		base.FixedUpdate();
		if (Input.GetKey(KeyCode.W)) {
			rb.AddForce(transform.right * force, ForceMode.Force);
		}
		EnforceBoundaries();
	}

	void fire() {
		GameObject bullet = Instantiate(beam, beamSpawnPos.transform.position, transform.rotation) as GameObject;
		//Debug.Log("Velocity: " + bullet.rb.velocity.magnitude);
		//bullet.rb.AddForce(
		Rigidbody beamRb = bullet.GetComponent<Rigidbody>();
		beamRb.AddForce(rb.velocity+beamRb.velocity, ForceMode.VelocityChange);//SON OF A BITCH
		
		//Debug.Log("Velocity: " + bullet.rb.velocity.magnitude);
	}

	/*public void takeDamage(float damage) {
		health -= damage;
		if (health <= 0)
			Debug.Log("SHIP DIED");
	}*/

	void UpdateHealthBar() {
		//healthBar.size = health / 100;
	}

	void setRotation() {
		Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));
	}

	void EnforceBoundaries() {
		if (transform.position.x < -90f) transform.position = new Vector3(-90f, transform.position.y, transform.position.z);
		if (transform.position.x > 90f) transform.position = new Vector3(90f, transform.position.y, transform.position.z);
		if (transform.position.y < -38f) transform.position = new Vector3(transform.position.x, -38f, transform.position.z);
		if (transform.position.y > 38f) transform.position = new Vector3(transform.position.x, 38f, transform.position.z);
	}
}
