﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private Rigidbody2D willyRB;
	private Animator anim;

	private bool facingRight;
	public float jumpHeight;
	public bool grounded;



	// Use this for initialization
	void Start () 
	{
		willyRB = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent <Animator> ();
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.A)) 
		{
			willyRB.velocity = new Vector2 (-speed * Time.deltaTime, willyRB.velocity.y);
		}
		if (Input.GetKey (KeyCode.D)) {
			willyRB.velocity = new Vector2 (speed * Time.deltaTime, willyRB.velocity.y);
		}
		if (Input.GetKeyDown (KeyCode.Space))
			{
				// Only jump if already on the ground
				if (grounded == true)
				{
					willyRB.AddForce (Vector2.up * jumpHeight);
				}
			}

		setGrounded ();
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw ("Horizontal");

		Animating (h);
		flip (h);
	}

	void Animating(float h)
	{
		bool walking = h != 0f;
		anim.SetBool ("Walking", walking);
	}

	void flip(float h)
	{
		if (h > 0 && !facingRight || h < 0 && facingRight) 
		{
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;
			theScale.x *= -1;

			transform.localScale = theScale;
		}
	}

	void setGrounded()
	{
		anim.SetBool ("Grounded", grounded);
		//Debug.Log ("Setting Grounded Status");
	}
}
