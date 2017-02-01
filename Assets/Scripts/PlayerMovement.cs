using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D willyRB;
	private Animator anim;
	private bool facingRight;
	public bool onRope;

	public float speed;
	public float jumpHeight;
	public bool grounded;
	public bool onLadder;

	public Transform rayStart;
	public Transform rayEnd;

	private Vector2 tempPos;

	// Use this for initialization
	void Start () 
	{
		willyRB = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent <Animator> ();
		facingRight = true;
		onRope = false;
        //respawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		tempPos = transform.position;

		rayCasting ();

		movement ();

		checkLadder ();
			
		setZRotation ();
		setGrounded ();
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw ("Horizontal");

		Animating (h);
		flip (h);
	}

	void movement()
	{
		if (Input.GetKey (KeyCode.A)) 
		{
			tempPos.x -= 2;
			transform.position = Vector2.Lerp (transform.position, tempPos, Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			tempPos.x += 2;
			transform.position = Vector2.Lerp (transform.position, tempPos, Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.Space) && onLadder == false)
		{
			// Only jump if already on the ground
			if (grounded == true)
			{
				willyRB.AddForce (Vector2.up * jumpHeight);
			}
		}

		if (Input.GetKey (KeyCode.W) && (onRope == true || onLadder == true)) 
		{
			tempPos.y += 1;
			transform.position = Vector2.Lerp (transform.position, tempPos, Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.S) && (onRope == true || onLadder == true))
		{
			tempPos.y -= 1;
			transform.position = Vector2.Lerp (transform.position, tempPos, Time.deltaTime);
		}
			
		if (onLadder == true) 
		{
			willyRB.velocity = new Vector2 (0.0f, 0.0f);
		}
	}

	void checkLadder()
	{
		if (onLadder == true) {
			willyRB.gravityScale = 0;
		} else
			willyRB.gravityScale = 1;
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

	void setZRotation()
	{
		if (transform.rotation.z != 0 && onRope == false)
		{
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
	}
		

	void setGrounded()
	{
		anim.SetBool ("Grounded", grounded);
		//Debug.Log ("Setting Grounded Status");
	}

	void rayCasting()
	{
		// Debug line so we can see where the line is in the editor
		Debug.DrawLine (rayStart.position, rayEnd.position, Color.magenta);

		// Sets the grounded bool too true if it casts 
		// onto anything with the "Ground" layer, false if not
		grounded = Physics2D.Linecast (rayStart.position, rayEnd.position,
			1 << LayerMask.NameToLayer("Ground"));
	}
}
