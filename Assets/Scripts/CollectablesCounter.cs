using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectablesCounter : MonoBehaviour 
{
	public Text displayScore;
	public int collect;

	// Use this for initialization
	void Start () 
	{
		collect = GameData.getCollect ();
		displayScore.text = collect.ToString();
	}

	void Update()
	{
		updateCounter ();
	}

	public void updateCounter()
	{
		collect = GameData.getCollect ();
		displayScore.text = collect.ToString();
	}
}
