using UnityEngine;
using System.Collections;

public class CemeraBehaviour : MonoBehaviour {

    public GameObject player;
    public Camera cam;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    public int minZoom;
    public int maxZoom;

   	void FixedUpdate ()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        float heightHalf = height / 2;
        float widthHalf = width / 2;
        
        if (transform.position.x < Map.X + widthHalf) transform.position = new Vector3(Map.X + widthHalf, transform.position.y, transform.position.z);
        if (transform.position.x > Map.X + Map.W - widthHalf) transform.position = new Vector3(Map.X + Map.W - widthHalf, transform.position.y, transform.position.z);
        if (transform.position.y < Map.Y + heightHalf) transform.position = new Vector3(transform.position.x, Map.Y + heightHalf, transform.position.z);
        if (transform.position.y > Map.Y+Map.H - heightHalf) transform.position = new Vector3(transform.position.x, Map.Y + Map.H - heightHalf, transform.position.z);

        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, -30);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
        // Mouse wheel zooming
        if (Input.GetAxis("Mouse ScrollWheel") > 0) cam.orthographicSize = Mathf.Max(Camera.main.orthographicSize - 1, minZoom);
        if (Input.GetAxis("Mouse ScrollWheel") < 0) cam.orthographicSize = Mathf.Min(Camera.main.orthographicSize + 1, maxZoom);
    }

    
}
