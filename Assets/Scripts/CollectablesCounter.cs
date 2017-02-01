using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectablesCounter : MonoBehaviour 
{

	public Text displayScore;
	public int endCollect;

	// Use this for initialization
	void Start () 
	{
		endCollect = GameData.getCollect ();
		displayScore.text = endCollect.ToString();
	}
}
