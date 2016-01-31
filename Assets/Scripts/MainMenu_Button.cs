using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu_Button : MonoBehaviour {

	[SerializeField] private Button startBtn;
	
	[SerializeField] private Button cntrlBtn;
	
	[SerializeField] private GameObject cntrl;
	[SerializeField] private string startSceneName;

	// Use this for initialization
	void Start () {
	
		cntrl.transform.localScale = new Vector3 (0, 0, 0);
	
		startBtn.onClick.AddListener (() =>
		{
			SceneManager.LoadScene(startSceneName);
		});
		
		
		cntrlBtn.onClick.AddListener (() =>
		{
			//RectTransform panelRectTransform = cntrl.transform as RectTransform;
			//panelRectTransform.offsetMax = new Vector2 (0, 0);
			//panelRectTransform.anchoredPosition = new Vector2(0,0);
			//panelRectTransform.sizeDelta = new Vector3 (1, 1, 1);
			cntrl.transform.localScale = new Vector3 (1, 1, 1);
			
		});
	
	}
}
