using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controlls_Buttons : MonoBehaviour 
{
	[SerializeField] private Button menuBtn;
	[SerializeField] private string mainMenuScene;

	// Use this for initialization
	void Start () 
	{
		menuBtn.onClick.AddListener (() =>
		{
			SceneManager.LoadScene(mainMenuScene);
		});

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
