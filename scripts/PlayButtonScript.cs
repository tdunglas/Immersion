using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

	public Button myButton;
	public string nextSceneName;

	// Use this for initialization
	void Start () {	
		Button btn = myButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void TaskOnClick(){
		Debug.Log("PlayButtonScript activated");
		SceneManager.LoadScene(nextSceneName);
	}
}
