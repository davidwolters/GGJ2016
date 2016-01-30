using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player_Points : MonoBehaviour {


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
			text.text = this.point.ToString();
			this.point = value;
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
