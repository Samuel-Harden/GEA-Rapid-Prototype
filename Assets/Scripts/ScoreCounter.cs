using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour 
{
	public Text displayScore;
	public int score;

	// Use this for initialization
	void Start () 
	{
		score = GameData.getScore ();
		displayScore.text = score.ToString();
	}

	void Update()
	{
		updateScore ();
	}

	public void updateScore()
	{
		score = GameData.getScore ();
		displayScore.text = score.ToString();
	}
}
