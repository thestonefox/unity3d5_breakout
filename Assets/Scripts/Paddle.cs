using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float speed = 1f;
	private Vector2 position = new Vector2(0, 0);

	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * speed);
		position = new Vector2 (Mathf.Clamp(xPos, -8f, 8f), transform.position.y);
		transform.position = position;
	}
}