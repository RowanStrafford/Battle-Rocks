using UnityEngine;
using System.Collections;

public class RockBehaviour : MonoBehaviour {

    public float rotateSpeed;
    private Vector3 rotation;

    private float health;	

	void Start ()
    {
        float meanRockSize = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
        health = 10 * meanRockSize;
	}
	
	void Update() {
		transform.Rotate(rotation * Time.deltaTime);
	}

    public void SetRotation(Vector3 rotation)
    {
		this.rotation = rotation;
    }

    public void SetHealth(float healthLost)
    {
        health = health - healthLost;
    }

    public float GetHealth()
    {
        return health;
    }
}
