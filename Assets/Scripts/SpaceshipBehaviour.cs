﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceshipBehaviour : MonoBehaviour {

    public GameObject beam;
    public GameObject beamSpawnPos;

    private float playerHealth = 100;
    public Scrollbar healthBar;

    SpaceshipMovement spaceshipMovementScript;

	void Start ()
    {
        spaceshipMovementScript = GetComponent<SpaceshipMovement>();
        UpdateHealthBar();
	}
	
	void Update ()
    {
	    if(Input.GetButtonDown("Fire1")) Instantiate(beam, beamSpawnPos.transform.position, transform.rotation);
    }

    void UpdateHealthBar()
    {
        healthBar.size = playerHealth / 100;
    }

    void OnCollisionEnter(Collision col)
    {
        
        Vector3 rockSize = col.transform.localScale;
        float meanSize = (rockSize.x + rockSize.y + rockSize.z) / 3;


        float playerSpeed = spaceshipMovementScript.GetPlayerSpeed();
        float speedAddition = Mathf.RoundToInt(playerSpeed);
        playerHealth -= Random.Range(1f, 3f) + speedAddition * meanSize;

        if (meanSize < 0.6f) return;
        UpdateHealthBar();
         
    }
}
