using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	public void OnTriggerEnter() {
		LevelManager.instance.LoseLife ();
	}
}