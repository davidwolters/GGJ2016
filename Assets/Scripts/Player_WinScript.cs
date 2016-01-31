using UnityEngine;
using System.Collections;

public class Player_WinScript : MonoBehaviour 
{
	[SerializeField] private Player_Points points1;
	[SerializeField] private Player_Points points2;
	[SerializeField] private int pointsToWin;
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
		} else if (points2.Point >= pointsToWin)
		{
			print ("PLAYER 2 WINS"); 
		}

	}
}
