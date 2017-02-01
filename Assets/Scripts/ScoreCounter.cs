using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour 
{

	public Text displayScore;
	public int endScore;

	// Use this for initialization
	void Start () 
	{
		endScore = GameData.getScore ();
		displayScore.text = endScore.ToString();
	}
}
