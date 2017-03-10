using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;


public class color : MonoBehaviour {

	private Wiimote wiimote; 

	public string direction="";
	// Use this for initialization
	void Start () {
		WiimoteManager.FindWiimotes();
		
	}
	
	// Update is called once per frame
	void Update () {
		DetectKeyPressed();
		Debug.Log(direction);
		couleur();
		if (!WiimoteManager.HasWiimote()) { 
			Debug.Log("no mote");
			return;
		}
		else{
			wiimote = WiimoteManager.Wiimotes[0];
			int ret;
		    do
		    {
		        ret = wiimote.ReadWiimoteData();
		    } while (ret > 0);

			//aDebug.Log(wiimote.Accel);
        	keywii();
/*
        	Debug.Log(wiimote.Ir.GetPointingPosition()[0]);
        	Debug.Log(wiimote.Ir.GetPointingPosition()[1]);*/
			
	        /*wiimote.Button.b;
	        wiimote.Button.one;
	       	wiimote.Button.two;
	        wiimote.Button.d_up;
	        wiimote.Button.d_down;
	        wiimote.Button.d_left;
	        wiimote.Button.d_right;
	       	wiimote.Button.plus;
	        wiimote.Button.minus;
	        wiimote.Button.home;*/

	        Debug.Log("read data from wii -" + wiimote.ReadWiimoteData());
	        string msg_accel = "accel :";

	        msg_accel += " x " + wiimote.Accel.GetCalibratedAccelData()[0];
	        msg_accel += " y " + wiimote.Accel.GetCalibratedAccelData()[1];
	        msg_accel += " z " + wiimote.Accel.GetCalibratedAccelData()[2];

	        Debug.Log(msg_accel);

	        alternateLed();
			
		}
		
	}

	void alternateLed(){
		int val = Random.Range(0,4);

		if(val == 0){
			wiimote.SendPlayerLED(true, false, false, false);
		}
		else if(val == 1){
			wiimote.SendPlayerLED(false, true, false, false);
		}
		else if(val == 2){
			wiimote.SendPlayerLED(false, false, true, false);
		}
		else if(val == 3){
			wiimote.SendPlayerLED(false, false, false, true);
		}
		
	}


	void DetectKeyPressed() {
		if (Input.GetKeyDown("up") || Input.GetKeyDown("z")) {
			direction="haut";
			
		} else if (Input.GetKeyDown("down")|| Input.GetKeyDown("s")) {
			direction="bas";

		} else if (Input.GetKeyDown("right") || Input.GetKeyDown("d")){
			direction="droite";

		} else if(Input.GetKeyDown("left") || Input.GetKeyDown("q")){
			direction="gauche";

		} else if(Input.GetKeyDown("a")){
			direction="add";
		}
		else if(Input.GetKeyDown("e")){
			direction="rmv";
		}
	}

	void keywii(){
		if (wiimote.Button.a) {
			direction="a";
		} else if (wiimote.Button.b) {
			direction="b";
		} else if (wiimote.Button.d_right) {
			direction="droite";
		} else if (wiimote.Button.d_up) {
			direction="haut";
		} else if (wiimote.Button.d_left) {
			direction="gauche";
		} else if (wiimote.Button.d_down) {
			direction="bas";
		} else if (wiimote.Button.plus) {
			direction="+";
		} else if (wiimote.Button.minus) {
			direction="-";
		} else if (wiimote.Button.one) {
			direction="1";
		} else if (wiimote.Button.two) {
			direction="2";
		} else if (wiimote.Button.home) {
			direction="h";
		} 

	}

	void couleur()
	{
		switch(direction) {
			case "haut":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0,1);
				break;
			case "gauche":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
				break;
			case "droite":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
				break;
			case "a":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1, 0);
				break;
			case "b":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
				break;
			case "+":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0);
				break;
			case "-":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
				break;
			case "1":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 0);
				break;
			case "2":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 1);
				break;
			case "h":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 0);
				break;
			case "bas":
				this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 1);
				break;	
			case "add":
				WiimoteManager.FindWiimotes();
				break;
			case "rmv":
				WiimoteManager.Cleanup(wiimote);
            	wiimote = null;
				break;
		}
		  // etc
	}
}
