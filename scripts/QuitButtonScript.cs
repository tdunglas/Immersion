using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButtonScript : MonoBehaviour {

	public Button myButton;
	// Use this for initialization
	void Start () {
		Button btn = myButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void TaskOnClick(){
		Debug.Log("QuitButtonScript activated");
		Application.Quit();
	}
}
