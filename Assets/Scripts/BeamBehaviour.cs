using UnityEngine;
using System.Collections;

public class BeamBehaviour : MonoBehaviour {

	//Physics
	public Rigidbody rb;
	public float density = 15f;
	public float speed;

	private float vel;
	public float minVel;
	private float lowVelTime = 0;


	//Class
	public GameObject[] rocks;
	public float dmgMult;
	private float health;
	public float lifeTime = 10f;
	
	void Start ()
    {
		//Physics
		vel = speed;
		rb.AddForce(transform.right * speed, ForceMode.VelocityChange);
		rb.SetDensity(density);

		health = 10 * rb.mass;
		//Debug.Log("Health: " + health);
		Destroy(gameObject, lifeTime);

	}
	
	void Update () {
		
		
	}

	void FixedUpdate() {
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;

		//Debug.Log(vel);
		vel = rb.velocity.magnitude;// velocity seems to have a delay to being set in the physics engine
		if (vel < minVel) {
			lowVelTime += Time.fixedDeltaTime;
		} else {
			lowVelTime = 0;
		}

		if (lowVelTime >= 0.05f) {
			transform.localScale = transform.localScale*0.9f;
			if((transform.localScale.x+ transform.localScale.y + transform.localScale.z) / 3 < 0.1f) {
				Destroy(gameObject);
				//Debug.Log("DESTROYING");
			}
			
		}
	}



	void OnCollisionEnter(Collision col) {

		float collisionForce = col.relativeVelocity.magnitude;
		Debug.Log(collisionForce);

		RockBehaviour rockBehaviour = col.gameObject.GetComponent<RockBehaviour>();
		rockBehaviour.takeDamage(collisionForce);
		//Destroy(gameObject);

	}
			
			/*
            RockBehaviour rockBehaviour = col.GetComponent<RockBehaviour>();
            Renderer rockRenderer = col.GetComponent<Renderer>();

            //Debug.Log(col.transform.localScale.x + col.transform.localScale.y + col.transform.localScale.z / 3);


            if (rockBehaviour.GetHealth() > 0)
            {
                rockBehaviour.takeDamage(damage);
            } else
            {
			*/
				/*
				1.rock is destroyed
				2.rock splits into smaller rocks unless that size is less than 0.5
					1.smaller rocks combined size = 2/3 of the parent rock
					2.the rocks' size is in the usual range//change rock create to accomodate any size (float)
					3.the number of rocks spawned should depend on the dmg dealt to them




				*/
				/*
                float meanRockSize = (col.transform.localScale.x + col.transform.localScale.y + col.transform.localScale.z) / 3;
                float adjustedMeanRockSize = meanRockSize * 0.8f; // Their will be some loss in the rock size
                int randNumOfRocks = Random.Range(3, 5);
                float sizePerRock = adjustedMeanRockSize / randNumOfRocks;

                for (int i = 0; i < randNumOfRocks; i++)
                {
                    int randRock = Random.Range(0, rocks.Length);

                    float xValue = rockRenderer.bounds.size.x / 2;
                    float xSpawn = col.transform.position.x - xValue;

                    float yValue = rockRenderer.bounds.size.y / 2;
                    float ySpawn = col.transform.position.y - yValue;

                    Vector3 rockSpawnPos = new Vector3(Random.Range(xSpawn, xSpawn + rockRenderer.bounds.size.x), Random.Range(ySpawn, ySpawn + rockRenderer.bounds.size.y), 0.0f);
                    GameObject rock = Instantiate(rocks[randRock], rockSpawnPos, Quaternion.identity) as GameObject;
                    rock.transform.localScale = new Vector3(sizePerRock, sizePerRock, sizePerRock);
                } 
                Destroy(col.gameObject);
             }
			 */
      //  }

       // Destroy(gameObject);

   // }
}
