using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_Buttons : MonoBehaviour 
{
	[SerializeField] private Button menuBtn;
	[SerializeField] private string menuScene;
	[SerializeField] private Button playAgainBtn;
	[SerializeField] private string gameScene;

	// Use this for initialization
	void Start () 
	{
		menuBtn.onClick.AddListener (() =>
		{
			SceneManager.LoadScene(menuScene);
		});

		playAgainBtn.onClick.AddListener (() =>
		{
			SceneManager.LoadScene(gameScene); 
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
