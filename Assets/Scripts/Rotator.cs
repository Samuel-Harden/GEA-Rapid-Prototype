using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float turnSpeed = 5.0f;
	public bool reverseRotation;

	// Use this for initialization
	void Start () {

		reverseRotation = true;
	}

	// Update is called once per frame
	void Update () {
	
		if (reverseRotation == true) 
		{
			transform.Rotate (Vector3.forward, -turnSpeed * Time.deltaTime);
		}
		if (reverseRotation == false) 
		{
			transform.Rotate (Vector3.forward, turnSpeed * Time.deltaTime);
		}
		checkRotation ();
	}

	void checkRotation()
	{
		if (transform.rotation.eulerAngles.z <= 60) 
		{
			reverseRotation = false;
		}
		if (transform.rotation.eulerAngles.z >= 120) 
		{
			reverseRotation = true;
		}
	}
}
