using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	// Array to hold all the games cameras
	public Camera[] cameraArray;

	void Start()
	{
		// Cycle through the cameras and disable them all except the first
		for (int i = 1; i < cameraArray.Length; i++)
		{
			cameraArray [i].enabled = false;
		}
	}

	// Simple function that changes between two cameras
	public void changeCamera(Camera cameraA, Camera cameraB)
	{
		if (cameraA.enabled == true) 
		{
			cameraA.enabled = false;
			cameraB.enabled = true;
			return;
		} 
		else
			cameraA.enabled = true;
		cameraB.enabled = false;
	}
}
