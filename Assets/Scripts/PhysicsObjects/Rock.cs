using UnityEngine;
using System.Collections;

public class Rock : PhysicsObject {

	public GameObject[] rocks;

	new void Start () {
		base.Start();
	}

	new void Update() {
		base.Update();
	}

	new void FixedUpdate() {
		base.FixedUpdate();
	}

	override protected void Die(float damage) {
		float size = transform.localScale.magnitude;

		int rockNum = Mathf.FloorToInt(1/(Mathf.Sqrt(maxHealth/damage))*3);
		//int rockNum = 3;

		Destroy(gameObject);

		if (size < 3)
			return;

		for (int i = 0; i < rockNum; i++) {
			GameObject rock = Instantiate(rocks[Random.Range(0, rocks.Length)], transform.position+ new Vector3(Random.Range(-2f, 2), Random.Range(-2f, 2), 0), Quaternion.identity) as GameObject;
			rock.transform.localScale = new Vector3(Random.Range(0.5f * transform.localScale.x, 0.7f * transform.localScale.x), Random.Range(0.5f * transform.localScale.y, 0.7f * transform.localScale.y), Random.Range(0.5f * transform.localScale.z, 0.7f * transform.localScale.z));
		}

	}

	protected override void EnforceBoundaries() {
		//if (transform.position.x < Map.X || transform.position.x > Map.X + Map.W || transform.position.y < Map.Y || transform.position.y > Map.Y + Map.H)
			//Die(1000);
	}

	/*1.rock is destroyed
	2.rock splits into smaller rocks unless that size is less than 0.5
	1.smaller rocks combined size = 2 / 3 of the parent rock
	2.the rocks' size is in the usual range//change rock create to accomodate any size (float)
	3.the number of rocks spawned should depend on the dmg dealt to them
	*/
}
