using UnityEngine;
using System.Collections;

public class Rock : PhysicsObject {

	new protected void Start () {
		base.Start();
	}

	new protected void Update() {
		base.Update();
	}

	new protected void FixedUpdate() {
		base.FixedUpdate();
		//if (rb.velocity.magnitude > 5)
		//	rb.velocity = rb.velocity.normalized * 5;
	}

	override protected void Die(float damage) {
		if (damage > 2*maxHealth)
			damage = maxHealth;

		float rockSizeVect = transform.localScale.magnitude;
		//float rockSize = (transform.localScale.x + transform.localScale.y + transform.localScale.z)/3;
		int rockNum = Mathf.FloorToInt(1/(Mathf.Sqrt(maxHealth/damage)))+3;
		Vector3 pos = transform.position;

		Destroy(gameObject);

		if (rockSizeVect < 1.2f)
			return;

		for (int i = 0; i < rockNum; i++) {
			GameObject rock = Instantiate(Map.rocks[Random.Range(0, Map.rocks.Length)], pos, Quaternion.identity) as GameObject;
			rock.transform.localScale = new Vector3(
				Random.Range(0.8f * rockSizeVect / rockNum, 1f * rockSizeVect / rockNum), Random.Range(0.8f * rockSizeVect / rockNum, 1f * rockSizeVect / rockNum), Random.Range(0.8f * rockSizeVect / rockNum, 1f * rockSizeVect / rockNum));
			Vector3 rockPos = new Vector3(Random.Range(-rockSizeVect / 2, rockSizeVect / 2), Random.Range(-rockSizeVect / 2, rockSizeVect / 2), 0);
			rockPos.z = 0;
			rock.transform.Translate(rockPos);
			Rigidbody rockRb = rock.GetComponent<Rigidbody>();
			rockRb.velocity += rb.velocity;
			rockRb.AddExplosionForce(damage/2, pos, rockSizeVect, 0, ForceMode.Impulse);
		}
	}

	override protected void EnforceBoundaries() {
		if (transform.position.x < Map.X -50|| transform.position.x > Map.X + Map.W+50 || transform.position.y < Map.Y-50 || transform.position.y > Map.Y + Map.H+50) {
			Destroy(gameObject);
		}
	}
}
