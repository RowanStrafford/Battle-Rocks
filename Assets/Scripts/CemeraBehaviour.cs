using UnityEngine;
using System.Collections;

public class CemeraBehaviour : MonoBehaviour {

    public GameObject player;
    public Camera cam;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Start ()
    {
	
	}
	
	void FixedUpdate ()
    {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10.0f);

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        float heightHalf = height / 2;
        float widthHalf = width / 2;


        if (transform.position.x < -90f + widthHalf) transform.position = new Vector3(-90f + widthHalf, transform.position.y, transform.position.z);
        if (transform.position.x > 90f - widthHalf) transform.position = new Vector3(90f - widthHalf, transform.position.y, transform.position.z);
        if (transform.position.y < -38f + heightHalf) transform.position = new Vector3(transform.position.x, -38f + heightHalf, transform.position.z);
        if (transform.position.y > 38f - heightHalf) transform.position = new Vector3(transform.position.x, 38f - heightHalf, transform.position.z);

        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10);


        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    
}
}
