using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class script_move : MonoBehaviour {

	//private GameObject go;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			//go.transform.Translate(Vector3(0.02, 0, 0));
		//transform.Translate(Vector3(0.02, 0, 0));
		/*rigidbody.AddForce(new Vector3(0.02,0,0)*10*Time.deltaTime);*/

		transform.position = transform.position + new Vector3(0.0f,0.0f,0.01f);
	}
}
