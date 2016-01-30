using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player_Points : MonoBehaviour {


	public int mana = 10;

	private Text text;
	[SerializeField] private GameObject TextObject;

	[SerializeField] private int point;
	[HideInInspector] public int Point
	{
		get
		{
			return this.point;
		}
		set
		{
			mana += (value * 2);
			text.text = this.point.ToString();
			this.point = value;
			print(Point);
		}
	}

	// Use this for initialization
	void Start ()
	{
	
		text = TextObject.GetComponent<Text>();
	
	}
	void OnGUI()
	{
		text.text = this.point.ToString();
	}
}
