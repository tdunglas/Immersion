using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {		
	}

	protected void OnGUI()
    {
    
    	string title = "IMMERSION";
    	int titleW = title.Length * 10;
    	GUIStyle guiStyle = new GUIStyle();
    	guiStyle.fontSize = 40;

    	GUI.Label(new Rect(Screen.width/2 - titleW, Screen.height/2, titleW, 30), title,guiStyle);  

    	string start = "START";
    	int startW = start.Length * 20;
    	if(GUI.Button(new Rect(Screen.width/2 - startW/2, Screen.height/2 - Screen.height/5, startW, 40), start)){
    		SceneManager.LoadScene("sceneNoManette");
    	}

    	string quit = "QUIT";
    	int quitW = quit.Length * 20;
    	if(GUI.Button(new Rect(Screen.width/2 - quitW/2, Screen.height/2 + Screen.height/5, quitW, 40), quit)){
    		Application.Quit();
    		Debug.Log("exit");
    	}
     
    }
}
