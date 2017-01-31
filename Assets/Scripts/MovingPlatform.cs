using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
	// Tick this if platform is horizontal
	public bool horPlatform;

	// Set the speed of the platform
	public float speed;

	// Set starting pos and target pos
	public float posX1;
	public float posX2;

	// Horizontal platform start moving right
	private bool movingRight;

	// Vertical platforms start moving upwards
	private bool movingUp;
		
	// Update is called once per frame
	void Update () 
	{
		if (horPlatform == true) {
			moveHorizontal ();
		} else
			moveVertical ();
	}

	void moveHorizontal()
	{
		// if moving right is true, move Right
		if (movingRight == true) 
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);

			// check position, if greater than the secondary pos
			if (transform.localPosition.x >= posX2) 
			{
				movingRight = false;
			}
		}

		if (movingRight == false) 
		{
			transform.Translate (-Vector2.right * speed * Time.deltaTime);

			if (transform.localPosition.x <= posX1) 
			{
				movingRight = true;
			}
		}
	}

	void moveVertical()
	{
		// if moving right is true, move Right
		if (movingUp == true) 
		{
			transform.Translate (Vector2.up * speed * Time.deltaTime);

			// check position, if greater than the secondary pos
			if (transform.localPosition.y >= posX2) 
			{
				movingUp = false;
			}
		}

		if (movingUp == false) 
		{
			transform.Translate (-Vector2.up * speed * Time.deltaTime);

			if (transform.localPosition.y <= posX1) 
			{
				movingUp = true;
			}
		}
	}
}
