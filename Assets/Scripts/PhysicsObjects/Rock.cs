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
		float rockSize = (transform.localScale.x + transform.localScale.y + transform.localScale.z)/3;
		int rockNum = Mathf.FloorToInt(1/(Mathf.Sqrt(maxHealth/damage)))+2;
		Vector3 pos = transform.position;

		Destroy(gameObject);

		if (rockSize < 0.8)
			return;

		for (int i = 0; i < rockNum; i++) {
			GameObject rock = Instantiate(rocks[Random.Range(0, rocks.Length)], pos, Quaternion.identity) as GameObject;
			rock.transform.localScale = new Vector3(
				Random.Range(0.8f * rockSize / rockNum, 1f * rockSize / rockNum), Random.Range(0.8f * rockSize / rockNum, 1f * rockSize / rockNum), Random.Range(0.8f * rockSize / rockNum, 1f * rockSize / rockNum));
			Vector3 rockPos = new Vector3(Random.Range(-rockSize / 2, rockSize / 2), Random.Range(-rockSize / 2, rockSize / 2), 0);
			rockPos.z = 0;
			rock.transform.Translate(rockPos);
			Rigidbody rockRb = rock.GetComponent<Rigidbody>();
			rockRb.velocity += rb.velocity;
			rockRb.AddExplosionForce(damage, pos, rockSize, 0, ForceMode.Impulse);
		}
	}

	override protected void EnforceBoundaries() {
		if (transform.position.x < Map.X -50|| transform.position.x > Map.X + Map.W+50 || transform.position.y < Map.Y-50 || transform.position.y > Map.Y + Map.H+50) {
			Destroy(gameObject);
		}
	}
}
