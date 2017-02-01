using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour 
{
	public GameObject player;

	public float speed = 6;

	void OnTriggerStay2D(Collider2D other)
	{

		player.GetComponent<PlayerMovement> ().onLadder = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player) 
		{
			player.GetComponent<PlayerMovement> ().onLadder = false;
		}
	}
}
