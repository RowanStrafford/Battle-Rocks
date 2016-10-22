using UnityEngine;
using System.Collections;

public class BeamBehaviour : MonoBehaviour {

    public GameObject[] rocks;

    public float speed;

	public float damage;

	public Rigidbody rb;
	public float bulletDensity = 10f;

	void Start ()
    {
		rb.AddForce(transform.right * 100 * speed);
		Destroy(gameObject, 10.0f);
		rb.SetDensity(bulletDensity);
	}
	
	void Update ()
    {
        //transform.Translate(Time.deltaTime * bulletSpeed, 0, 0);//Change to force
	}

	void FixedUpdate() {
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Rock")
        {
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
        }

       // Destroy(gameObject);

    }
}
