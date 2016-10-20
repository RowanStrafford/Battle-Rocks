using UnityEngine;
using System.Collections;

public class CemeraBehaviour : MonoBehaviour {

    public GameObject player;
    public Camera cam;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10.0f);

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        float heightHalf = height / 2;
        float widthHalf = width / 2;


        if (transform.position.x < -90f + widthHalf) transform.position = new Vector3(-90f + widthHalf, transform.position.y, transform.position.z);
        if (transform.position.x > 90f - widthHalf) transform.position = new Vector3(90f - widthHalf, transform.position.y, transform.position.z);
        if (transform.position.y < -38f + heightHalf) transform.position = new Vector3(transform.position.x, -38f + heightHalf, transform.position.z);
        if (transform.position.y > 38f - heightHalf) transform.position = new Vector3(transform.position.x, 38f - heightHalf, transform.position.z);
    }
}
