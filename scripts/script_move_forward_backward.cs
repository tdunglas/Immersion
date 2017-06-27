using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class script_move_forward_backward : MonoBehaviour {

	private int limite = 50;
	private int pas = 0;
	private bool forward = true;

	private GameObject go;


	// Use this for initialization
	void Start () {


		/*go = new GameObject("testProjectile");
		go.transform.localScale = new Vector3(0.1f,0.1f,0.1f);

		Instantiate(go);*/

		go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		go.transform.position = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
			//go.transform.Translate(Vector3(0.02, 0, 0));
		//transform.Translate(Vector3(0.02, 0, 0));
		/*rigidbody.AddForce(new Vector3(0.02,0,0)*10*Time.deltaTime);*/


		
		if(pas > limite){
			forward = false;
		}
		else if(pas < 0){
			forward = true;
		}

		if(forward){
			transform.position = transform.position + new Vector3(0.0f,0.0f,0.02f);

			go.transform.position = transform.position + new Vector3(0.0f,0.0f,0.5f);

			pas++;
		}
		else{
			transform.position = transform.position - new Vector3(0.0f,0.0f,0.02f);
			pas--;
		}
	}
}
