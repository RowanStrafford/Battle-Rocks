﻿using UnityEngine;
using System.Collections;
using System;

public class Rock : PhysicsObject {

	//Physics
	static float DEFAULT_DENSITY = 2f;


	new void Start ()
    {
		base.Start();
		//Physics
        //float meanRockSize = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
		
		Debug.Log("Health: " + health + ", mass: " + rb.mass);
	}

	new void Update() {	}

	new void FixedUpdate() {
		base.FixedUpdate();
	}

    

}
