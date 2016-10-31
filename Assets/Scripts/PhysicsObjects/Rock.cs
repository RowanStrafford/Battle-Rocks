using UnityEngine;
using System.Collections;

public class Rock : PhysicsObject {

	new protected void Start () {
		base.Start();
		immune = -5;
	}

	new protected void Update() {
		base.Update();
	}

	new protected void FixedUpdate() {
		base.FixedUpdate();
	}

	override protected void Die(float damage) {
		if (damage > 4*maxHealth)
			damage = 4*maxHealth;

		float rockSize = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;

		int rockNum = Mathf.FloorToInt(2 * damage / maxHealth) + Random.Range(2, 5);
		Vector3 pos = transform.position;
		
		Destroy(gameObject);

		if (rockSize < 1)
			return;

		for (int i = 0; i < rockNum; i++) {
			GameObject rock = Instantiate(Map.rocks[Random.Range(0, Map.rocks.Length)], pos, Quaternion.identity) as GameObject;

			//rock.transform.localScale = transform.localScale / rockNum;
			rock.transform.localScale = new Vector3(
				Random.Range(0.4f * rockSize / Mathf.Sqrt(rockNum), 0.9f * rockSize / Mathf.Sqrt(rockNum)), Random.Range(0.4f * rockSize / Mathf.Sqrt(rockNum), 0.9f * rockSize / Mathf.Sqrt(rockNum)), Random.Range(0.4f * rockSize / rockNum, 0.9f * rockSize / rockNum));
			Vector3 rockPos = new Vector3(Random.Range(-rockSize / 2, rockSize / 2), Random.Range(-rockSize / 2, rockSize / 2), 0);
			rockPos.z = 0;
			rock.transform.Translate(rockPos);
			Rigidbody rockRb = rock.GetComponent<Rigidbody>();
			rockRb.velocity += rb.velocity;
			rockRb.AddExplosionForce(Mathf.Sqrt(damage)*2, pos, rockSize/1.5f, 0, ForceMode.Impulse);
		}
	}

	override protected void EnforceBoundaries() {
		if (transform.position.x < Map.X - 60|| transform.position.x > Map.X + Map.W + 60 || transform.position.y < Map.Y - 60 || transform.position.y > Map.Y + Map.H + 60) {
			Destroy(gameObject);
		}
	}
}
