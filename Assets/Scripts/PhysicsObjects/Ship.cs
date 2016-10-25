using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Ship : PhysicsObject {

	public float force;

	public GameObject beam;
	public GameObject beamSpawnPos;

	//Thruster
    public Scrollbar healthBar;
    public GameObject thruster;
    private ParticleSystem particle;
    ParticleSystem.EmissionModule emmisions;

    private AudioSource audio;
    public AudioClip beamPowerOn;

    //private AudioSource audio;
    public AudioClip laserShot;


    private float fireRateTimer = 0f;
    public float maxBeamPower = 3f;

    new protected void Start() {
        base.Start();
		UpdateHealthBar();

        particle = thruster.GetComponent<ParticleSystem>();
        emmisions = particle.emission;
        emmisions.enabled = false;
		audio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    new protected void Update () {
		base.Update();
		setRotation();		

        if(Input.GetButton("Fire1"))
        {
            if(audio.isPlaying == false) audio.PlayOneShot(beamPowerOn);            
            
            fireRateTimer += Time.deltaTime;

            if (fireRateTimer > maxBeamPower) fire(fireRateTimer);
            
        }

        if(Input.GetButtonUp("Fire1"))
        {
            audio.Stop();

            if (fireRateTimer < 1f) fireRateTimer = 1f;

            fire(fireRateTimer);

        }


        if (Input.GetKeyDown(KeyCode.W))
			emmisions.enabled = true;
        if (Input.GetKeyUp(KeyCode.W))
			emmisions.enabled = false;	
	}

	new protected void FixedUpdate() {
		base.FixedUpdate();
		if (Input.GetKey(KeyCode.W)) {
			rb.AddForce(transform.right * force - (rb.velocity / force*4), ForceMode.Force);
		}
		EnforceBoundaries();
		if (health < maxHealth) {
			health = health + 0.1f;
			UpdateHealthBar();
		}
	}

	void fire(float speedMultiplier) {
		GameObject bullet = Instantiate(beam, beamSpawnPos.transform.position, transform.rotation) as GameObject;
        Rigidbody beamRb = bullet.GetComponent<Rigidbody>();
        Beam beamScript = bullet.GetComponent<Beam>();

        beamScript.velMultiplier = speedMultiplier;
		beamRb.velocity += rb.velocity;
        
        fireRateTimer = 0f;
        audio.PlayOneShot(laserShot);
	}

	override protected void OnCollisionEnter(Collision col) {
		base.OnCollisionEnter(col);
		UpdateHealthBar();
		
	}

	override public void takeDamage(float damage) {
		health -= damage;
		if (health <= 0)
			SceneManager.LoadScene(0);
	}

	void UpdateHealthBar() {
		healthBar.size = (health / maxHealth);
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
			transform.position = new Vector3(Map.X, transform.position.y, transform.position.z);
		if (transform.position.x > Map.X + Map.W)
			transform.position = new Vector3(Map.X+Map.W, transform.position.y, transform.position.z);
		if (transform.position.y < Map.Y)
			transform.position = new Vector3(transform.position.x, Map.Y, transform.position.z);
		if (transform.position.y > Map.Y + Map.H)
			transform.position = new Vector3(transform.position.x, Map.Y+Map.H, transform.position.z);
	}
}
