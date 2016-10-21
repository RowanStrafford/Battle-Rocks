using UnityEngine;
using System.Collections;

public class SpaceshipMovement : MonoBehaviour {

    public float moveSpeed;
    public float maxSpeed;
    public float boostSpeed;
    public GameObject cameraObject;

    private float speedUpTimer = 0f;

    public float force = 3.0f;
    private Rigidbody rb;

    public GameObject thrusters;

    private ParticleSystem particles;
    ParticleSystem.EmissionModule emmisions;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        particles = thrusters.GetComponent<ParticleSystem>();
        emmisions = particles.emission;
        emmisions.enabled = false;

    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.W)) emmisions.enabled = true;

        if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.UpArrow))) emmisions.enabled = false;
        

        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));

        if (transform.position.x < -90f) transform.position = new Vector3(-90f, transform.position.y, transform.position.z);
        if (transform.position.x > 90f) transform.position = new Vector3(90f, transform.position.y, transform.position.z);
        if (transform.position.y < -38f) transform.position = new Vector3(transform.position.x, -38f, transform.position.z);
        if (transform.position.y > 38f) transform.position = new Vector3(transform.position.x, 38f, transform.position.z);

        //cameraObject.transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
    }    

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.magnitude > maxSpeed) rb.velocity = rb.velocity.normalized * maxSpeed;
            else rb.AddForce(transform.right * force);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        
    }

    public float GetPlayerSpeed()
    {
        return rb.velocity.magnitude;
    }
}
