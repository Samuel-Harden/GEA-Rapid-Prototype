using UnityEngine;
using System.Collections;

public class PlatformCheck : MonoBehaviour {

	private BoxCollider2D coll;

	void Start()
	{
		coll = GetComponent<BoxCollider2D>();
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Debug.Log ("Its the player");
			if (Input.GetKey (KeyCode.S))
			{
				Debug.Log ("Disabling");
				coll.enabled = !coll.enabled;
				StartCoroutine (enableCollider ());
			}
		}
	}

	IEnumerator enableCollider()
	{
		yield return new WaitForSeconds (1);
		coll.enabled = !coll.enabled;
	}
}