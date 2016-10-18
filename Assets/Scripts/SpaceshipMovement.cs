using UnityEngine;
using System.Collections;

public class SpaceshipMovement : MonoBehaviour {

    public float moveSpeed;

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
    }
}
