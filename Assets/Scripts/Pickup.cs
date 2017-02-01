using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject player;
	public GameData gameManager;

	// Use this for initialization
	void Start () {
	
		//player = GameObject.FindGameObjectWithTag (tag:player);
	}
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject == player) 
		{
			Destroy (gameObject);
			Debug.Log ("Willy has collected me");
			gameManager.itemCollected ();

		}
	}
}