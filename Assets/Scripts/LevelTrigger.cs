using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour
{
	public GameObject player;
	public CameraControl _cameraControl;
	public Camera cameraA;
	public Camera cameraB;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject == player) 
		{
			_cameraControl.changeCamera (cameraA, cameraB);
			Debug.Log ("Willy has changed level");
		}
	}
}