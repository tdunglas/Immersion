using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIscenePrincipale : MonoBehaviour {

    public int score;
    public int levelSore = 5;
    public float timeEnd;
    public float timeLeft;
    public float timeValue = 30f;
	
	// Use this for initialization
	void Start () {
		timeEnd = Time.time + timeValue;
	}
	
	// Update is called once per frame
	void Update () {
		
		timeLeft = timeEnd - Time.time;
        if(timeLeft <= 0 && score < levelSore){
            SceneManager.LoadScene("sceneGameOver");
        }

        else if(timeLeft <= 0 && score >= levelSore){
            SceneManager.LoadScene("sceneWinGame");
        }
	}
	
	void OnGUI()
    {
		//Debug.Log("START OF GUI");
		
		GameObject pc = GameObject.Find("_PlayerManager");
		//GameObject lc = pc.transform.GetChild(0).gameObject;
		int lc = pc.GetComponent<LaserScript>().score;

        int nbCubes = 0;
        //nbCubes = lc.GetComponent<LaserScript>().score;
        nbCubes = lc;
		
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 30;
        score = nbCubes;

        GUILayout.Label("cubes détruits : " + nbCubes + " / " + levelSore, guiStyle);
        GUILayout.Label("time left : " + timeLeft + " secondes", guiStyle);

        string pointer = "+";
        int pointerW = pointer.Length * 10;
        GUI.Label(new Rect(Screen.width/2, Screen.height/2, pointerW, 30),"+", guiStyle);
		
		//string msg = "Time : " + Time.time;
		//GUI.Label(new Rect(10,10,100,30), msg);
		//Debug.Log("END OF GUI");
    }
}
