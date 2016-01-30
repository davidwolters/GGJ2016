using UnityEngine;
using System.Collections;

public class Player_Points : MonoBehaviour {


	private int point;
	[HideInInspector] public int Point
	{
		get
		{
			return this.point;
		}
		set
		{
			this.point = value;
			print(Point);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
