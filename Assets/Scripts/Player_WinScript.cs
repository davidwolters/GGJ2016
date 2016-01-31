using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Player_WinScript : MonoBehaviour 
{
	[SerializeField] private Player_Points points1;
	[SerializeField] private Player_Points points2;
	[SerializeField] private int pointsToWin;

	private string wonPlayer;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (points1.Point >= pointsToWin)
		{
			// PL 1 WINS
			print ("PLAYER 1 WINS"); 
			wonPlayer = "1";
			Invoke ("SwitchToGameOverScene", 1f);
		} else if (points2.Point >= pointsToWin)
		{
			print ("PLAYER 2 WINS"); 
			wonPlayer = "2";
			Invoke ("SwitchToGameOverScene", 1f);
		}

	}

	void SwitchToGameOverScene ()
	{
		SceneManager.LoadScene (0);
	}

}
