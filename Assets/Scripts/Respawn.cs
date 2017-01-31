using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	private Vector3 respawnPoint;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			transform.position = respawnPoint;
		}

		if (other.tag == "Checkpoint")
		{
			Debug.Log ("Setting new Waypoint");
			respawnPoint = other.transform.position;
		}
	}
}
