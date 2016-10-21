using UnityEngine;
using System.Collections;

public class RockWrapperBehaviour : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
		//transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, 0);
	}
	
	void Update () {
		//transform.Translate(Time.deltaTime * speed, 0, 0);//replace with force
		

        if (transform.childCount == 0)
        {
            Destroy(gameObject);
            return;
        }

        
	}

	void FixedUpdate() {
		

	}


}
