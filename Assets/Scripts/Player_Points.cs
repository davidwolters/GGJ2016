using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player_Points : MonoBehaviour {


	public int mana = 100;

	[SerializeField] private Text scoreText;
	[SerializeField] private Text manaText;

	[SerializeField] private int point;

	[HideInInspector] public int Point
	{
		get
		{
			return this.point;
		}
		set
		{
			mana += (value * 20);
			if (mana > 100)
				mana = 100;
			this.point = value;
			print(Point);
		}
	}


	// Use this for initialization
	void Start ()
	{
	
		
	}
	void OnGUI()
	{
		scoreText.text = this.point.ToString();
		manaText.text = this.mana.ToString ();
	}
}
