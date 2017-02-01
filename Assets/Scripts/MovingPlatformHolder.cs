using UnityEngine;
using System.Collections;

public class MovingPlatformHolder : MonoBehaviour 
{
	public GameObject player;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) 
		{
			player.transform.parent = gameObject.transform;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player) 
		{
			player.transform.parent = null;
		}
	}
}
