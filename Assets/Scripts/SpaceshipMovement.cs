using UnityEngine;
using System.Collections;

public class SpaceshipMovement : MonoBehaviour {

    public float moveSpeed;
    public GameObject cameraObject;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    if((Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow))))
        {
            transform.Translate(Time.deltaTime * moveSpeed, 0, 0);
        }
        else if ((Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow))))
        {
            transform.Translate(-Time.deltaTime * moveSpeed, 0, 0);
        }

        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));

        if (transform.position.x < -50.0f) transform.position = new Vector3(-50.0f, transform.position.y, transform.position.z);
        if (transform.position.x > 50.0f) transform.position = new Vector3(50.0f, transform.position.y, transform.position.z);
        if (transform.position.y < -25.0f) transform.position = new Vector3(transform.position.x, -25.0f, transform.position.z);
        if (transform.position.y > 25.0f) transform.position = new Vector3(transform.position.x, 25.0f, transform.position.z);

        cameraObject.transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
    }
}
