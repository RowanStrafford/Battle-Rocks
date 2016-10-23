using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ship : PhysicsObject {

	public float force = 3.0f;

	public GameObject beam;
	public GameObject beamSpawnPos;

	//Thruster
    public Scrollbar healthBar;
    public GameObject thruster;
    private ParticleSystem particle;
    ParticleSystem.EmissionModule emmisions;

    new void Start () {
		base.Start();
		UpdateHealthBar();

        particle = thruster.GetComponent<ParticleSystem>();
        emmisions = particle.emission;
        emmisions.enabled = false;
    }

	// Update is called once per frame
	new void Update () {
		setRotation();
		if (Input.GetButtonDown("Fire1"))//why does this need to be in update
			fire();
        if (Input.GetKeyDown(KeyCode.W))
			emmisions.enabled = true;
        if (Input.GetKeyUp(KeyCode.W))
			emmisions.enabled = false;
		if (Input.GetKey(KeyCode.W)) {
			rb.AddForce(transform.right * force-(rb.velocity/10), ForceMode.Force);
		}
	}

	new void FixedUpdate() {
		base.FixedUpdate();
		
		EnforceBoundaries();
	}

	void fire() {
		GameObject bullet = Instantiate(beam, beamSpawnPos.transform.position, transform.rotation) as GameObject;
		Rigidbody beamRb = bullet.GetComponent<Rigidbody>();
		beamRb.velocity += rb.velocity;
	}

	override protected void OnCollisionEnter(Collision col) {
		base.OnCollisionEnter(col);
		UpdateHealthBar();
	}

	override public void takeDamage(float damage) {
		health -= damage;
		if (health <= 0)
			Debug.Log("SHIP DEAD");
	}

	void UpdateHealthBar() {
		healthBar.size = health / maxHealth;
	}

	void setRotation() {
		Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));
	}

	override protected void EnforceBoundaries() {
		if (transform.position.x < Map.X)
			transform.position = new Vector3(-90f, transform.position.y, transform.position.z);
		if (transform.position.x > Map.X + Map.W)
			transform.position = new Vector3(90f, transform.position.y, transform.position.z);
		if (transform.position.y < Map.Y)
			transform.position = new Vector3(transform.position.x, -38f, transform.position.z);
		if (transform.position.y > Map.Y + Map.H)
			transform.position = new Vector3(transform.position.x, 38f, transform.position.z);
	}
}
