using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Companion : PhysicsObject {

	public float force;

	public GameObject beam;
	public GameObject beamSpawnPos;

	//Thruster
    public GameObject thruster;
    private ParticleSystem particle;
    ParticleSystem.EmissionModule emmisions;

	//Audio
	private AudioSource companionAudio;
	public AudioClip dead;

	new protected void Start() {
        base.Start();

        particle = thruster.GetComponent<ParticleSystem>();
        emmisions = particle.emission;
        emmisions.enabled = false;

		companionAudio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    new protected void Update () {
		base.Update();
		setRotation();

		inputs();
   	}

	void inputs() {
		if (Input.GetButton("Fire1")) {

		}

		if (Input.GetButtonUp("Fire1")) {
			fire(1, 1);
		}

		if (Input.GetKeyDown(KeyCode.W))
			emmisions.enabled = true;
		if (Input.GetKeyUp(KeyCode.W))
			emmisions.enabled = false;
	}

	void fire(float speedMultiplier = 1f, int power = 1) {
		GameObject proj = Instantiate(beam, beamSpawnPos.transform.position, transform.rotation) as GameObject;
		Rigidbody beamRb = proj.GetComponent<Rigidbody>();
		beamRb.velocity += rb.velocity;
		
		Beam beamScript = proj.GetComponent<Beam>();

		beamScript.velMult = speedMultiplier;
		beamScript.modVel = true;
		beamScript.team = team;

		switch (power) {
			case 0:
				beamScript.densMult = 0.75f;
				beamRb.transform.localScale = beamRb.transform.localScale * 0.6f;
				break;
			case 1:
				beamScript.densMult = 1f;
				//beamRb.transform.localScale = beamRb.transform.localScale * 1f;
				break;
			case 2:
				beamScript.densMult = 1.25f;
				beamRb.transform.localScale = beamRb.transform.localScale * 1.5f;
				break;
			default:
				beamScript.densMult = 0.05f;
				break;
		}
		beamScript.modDens = true;
	}

	override public void takeDamage(float damage) {
		health -= damage;
		if (health <= 0) {
			companionAudio.PlayOneShot(dead);
			Destroy(gameObject, 0.3f);
		}

	}

	new protected void FixedUpdate() {
		base.FixedUpdate();
		if (Input.GetKey(KeyCode.W)) {
			rb.AddForce(transform.right * force - (rb.velocity * rb.velocity.magnitude / maxVel), ForceMode.Force);
		}
		EnforceBoundaries();
		if (health < maxHealth) {
			health = health + 0.1f;
		}
	}
	
	void setRotation() {
		Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(180, 0, -playerRotationAngle));
		//Vector3 rot = transform.rotation.eulerAngles;
		//rot = new Vector3(rot.x+180, rot.y, rot.z);
		//transform.rotation = Quaternion.Euler(-rot);


		//ROTATE SHIP WHILE TURNING //TODO
		//transform.Rotate(30,0,30);

		//transform.Rotate(-30, 0, -30);
	}

	override protected void EnforceBoundaries() {
		if (transform.position.x < Map.X)
			transform.position = new Vector3(Map.X, transform.position.y, transform.position.z);
		if (transform.position.x > Map.X + Map.W)
			transform.position = new Vector3(Map.X+Map.W, transform.position.y, transform.position.z);
		if (transform.position.y < Map.Y)
			transform.position = new Vector3(transform.position.x, Map.Y, transform.position.z);
		if (transform.position.y > Map.Y + Map.H)
			transform.position = new Vector3(transform.position.x, Map.Y+Map.H, transform.position.z);
	}
}
