using UnityEngine;
using System.Collections;

public class GroundedCheck : MonoBehaviour 
{
	public PlayerMovement _playerMovement;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			_playerMovement.grounded = true;
			Debug.Log ("Touching the floor");
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			_playerMovement.grounded = false;
			Debug.Log ("In the Air");
		}
	}
}