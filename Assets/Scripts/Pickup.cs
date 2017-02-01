using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pickup : MonoBehaviour {

	public GameObject player;
	private GameData gameManager;

    // Use this for initialization
    void Start () {

        //player = GameObject.FindGameObjectWithTag (tag:player);
       gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameData>();
    }
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject == player) 
		{
            //adds an addition to collectables
            gameManager.itemCollected();
            //destroys the game object
            Destroy(gameObject);
			Debug.Log ("Willy has collected me");

		}
	}
}