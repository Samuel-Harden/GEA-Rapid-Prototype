using UnityEngine;
using System.Collections;

public class RopeHolder : MonoBehaviour {

	public GameObject player;
	private CircleCollider2D coll;
	private bool playerAttached;

	void Start()
	{
		coll = gameObject.GetComponent<CircleCollider2D> ();
		playerAttached = false;
	}

	void Update()
	{
		if (playerAttached == true) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				Debug.Log ("Disabling");
				releasePlayer ();
				coll.enabled = !coll.enabled;
				StartCoroutine (enableCollider ());
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) 
		{
			Debug.Log ("Attaching Player to Platform");
			player.transform.parent = gameObject.transform;
			player.GetComponent<Rigidbody2D> ().isKinematic = true;
			player.GetComponent<PlayerMovement> ().onRope = true;
			playerAttached = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player) 
		{
			releasePlayer ();
		}
	}

	void releasePlayer()
	{
		//Debug.Log ("Removing child object");
		player.transform.parent = null;
		player.GetComponent<Rigidbody2D> ().isKinematic = false;
		player.GetComponent<PlayerMovement> ().onRope = false;
		playerAttached = false;
	}

	IEnumerator enableCollider()
	{
		yield return new WaitForSeconds (1);
		coll.enabled = !coll.enabled;
	}
}
