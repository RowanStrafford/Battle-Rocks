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
	}

	override protected void Die(float damage) {
		if (damage > 2*maxHealth)
			damage = 2*maxHealth;

		float rockSizeVect = transform.localScale.magnitude;
		int rockNum = Mathf.FloorToInt(1/(Mathf.Sqrt(maxHealth/damage)))+3;
		Vector3 pos = transform.position;

		Destroy(gameObject);

		if (rockSizeVect < 1.7f)
			return;

		for (int i = 0; i < rockNum; i++) {
			GameObject rock = Instantiate(Map.rocks[Random.Range(0, Map.rocks.Length)], pos, Quaternion.identity) as GameObject;
			rock.transform.localScale = new Vector3(
				Random.Range(0.4f * rockSizeVect / rockNum, 1.05f * rockSizeVect / rockNum), Random.Range(0.4f * rockSizeVect / rockNum, 1.05f * rockSizeVect / rockNum), Random.Range(0.4f * rockSizeVect / rockNum, 1.05f * rockSizeVect / rockNum));
			Vector3 rockPos = new Vector3(Random.Range(-rockSizeVect / 2, rockSizeVect / 2), Random.Range(-rockSizeVect / 2, rockSizeVect / 2), 0);
			rockPos.z = 0;
			rock.transform.Translate(rockPos);
			Rigidbody rockRb = rock.GetComponent<Rigidbody>();
			rockRb.velocity += rb.velocity;
			rockRb.AddExplosionForce(damage/3f, pos, rockSizeVect, 0, ForceMode.Impulse);
		}
	}

	override protected void EnforceBoundaries() {
		if (transform.position.x < Map.X - 30|| transform.position.x > Map.X + Map.W + 30 || transform.position.y < Map.Y - 30 || transform.position.y > Map.Y + Map.H + 30) {
			Destroy(gameObject);
		}
	}
}
