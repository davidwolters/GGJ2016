using UnityEngine;
using UnityEngine.UI;

public class GameOver_Buttons : MonoBehaviour 
{
	[SerializeField] private Button menuBtn;
	[SerializeField] private Button playAgainBtn;

	// Use this for initialization
	void Start () 
	{
		menuBtn.onClick.AddListener (() =>
		{
			print ("MENU");
		});

		playAgainBtn.onClick.AddListener (() =>
		{
			print ("PLAY AGAIN"); 
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
