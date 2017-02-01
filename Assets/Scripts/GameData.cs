using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour {

	// needs to be static so we canpass it between scenes!
	public int playerLives;
	public static int score;
	public static int colFound;

	public int totalCollectables;

	// Use this for initialization
	void Start () 
	{
		colFound = 0;
		playerLives = 5;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerLives == 0) 
		{
			GameOver ();
		}
	}

	public void died()
	{
		playerLives -= 1;
	}

	public void itemCollected()
	{
		colFound += 1;
		score += 100;

		if (colFound == totalCollectables) 
		{
			SceneManager.LoadScene ("GameWon");
		}
	}

    public int getLives()
    {
        return playerLives;
    }

	public static int getScore()
	{
		return score;
	}

	public int getCollect()
	{
		return colFound;
	}

	void GameOver()
	{
		Debug.Log ("Game Over");
		SceneManager.LoadScene("EndGame");
	}
}
