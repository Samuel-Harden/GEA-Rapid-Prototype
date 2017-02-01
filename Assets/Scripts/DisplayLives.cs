using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayLives : MonoBehaviour 
{
	public Text displayLives;
	public int lives;

	// Use this for initialization
	void Start () 
	{
		lives = GameData.getLives ();
		displayLives.text = lives.ToString();
	}

	void Update()
	{
		updateLives ();
	}

	public void updateLives()
	{
		lives = GameData.getLives ();
		displayLives.text = lives.ToString();
	}
}
