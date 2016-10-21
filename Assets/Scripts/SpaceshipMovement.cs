using UnityEngine;
using System.Collections;

public class SpaceshipMovement : MonoBehaviour {

    public float moveSpeed;
    public float boostSpeed;
    public GameObject cameraObject;

    //private float speedUpTimer = 0f;

    public float force = 3.0f;
    private Rigidbody rb;

    public GameObject thruster1;
    public GameObject thruster2;

    private ParticleSystem particle1;
    private ParticleSystem particle2;

    ParticleSystem.EmissionModule emmisions1;
    ParticleSystem.EmissionModule emmisions2;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        particle1 = thruster1.GetComponent<ParticleSystem>();
        particle2 = thruster2.GetComponent<ParticleSystem>();

        emmisions1 = particle1.emission;
        emmisions2 = particle2.emission;

        emmisions1.enabled = false;
        emmisions2.enabled = false;
    }

    void Update ()
    {
		if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.UpArrow))) {
			emmisions1.enabled = false;
			emmisions2.enabled = false;
		}
        if(Input.GetKeyDown(KeyCode.W))
        {
            emmisions1.enabled = true;
            emmisions2.enabled = true;
        }

        //if (Input.GetKey(KeyCode.W))
        //{
         //   speedUpTimer += Time.deltaTime;
         //   if (speedUpTimer > 1.0f) transform.Translate(Time.deltaTime * boostSpeed, 0, 0);              
          //  else transform.Translate(Time.deltaTime * moveSpeed, 0, 0);
        //}
       // else if ((Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))) transform.Translate(-Time.deltaTime * moveSpeed, 0, 0);

        //if (Input.GetKeyUp(KeyCode.W))
        //{
            //speedUpTimer = 0f;
         //   emmisions1.enabled = false;
         //   emmisions2.enabled = false;
        //}

        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

		float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));

		EnforceBoundaries();
    }    

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.right * force);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

	void EnforceBoundaries() {
		if (transform.position.x < -90f) transform.position = new Vector3(-90f, transform.position.y, transform.position.z);
		if (transform.position.x > 90f) transform.position = new Vector3(90f, transform.position.y, transform.position.z);
		if (transform.position.y < -38f) transform.position = new Vector3(transform.position.x, -38f, transform.position.z);
		if (transform.position.y > 38f) transform.position = new Vector3(transform.position.x, 38f, transform.position.z);
	}

	public float GetSpeed()
    {
        return rb.velocity.magnitude;
    }
}
