using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float initialVelocity = 500f;

	private Rigidbody rb;
	private bool ballInPlay;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (! ballInPlay && Input.GetButtonDown ("Fire1")) {
			ballInPlay = true;
			transform.parent = null;
			rb.isKinematic = false;
			rb.AddForce(new Vector3 (initialVelocity, initialVelocity, 0));
		}
	}
}