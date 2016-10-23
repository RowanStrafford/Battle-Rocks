using UnityEngine;
using System.Collections;
using System;

public class Rock : PhysicsObject {

	//Physics
	static float DEFAULT_DENSITY = 2f;

	new void Start ()
    {
		base.Start();
	}

	new void Update() {	}

	new void FixedUpdate() {
		base.FixedUpdate();
	}
}
