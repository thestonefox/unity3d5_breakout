using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public GameObject brickBreakParticles;

	void OnCollisionEnter() {
		LevelManager.instance.HitBrick ();
		Instantiate (brickBreakParticles, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
