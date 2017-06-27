using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviorScript : MonoBehaviour {

	public float mScaleMax = 2f;
	public float mScaleMin = 0.5f;
	public float mOrbitMaxSpeed = 30f;

	private float mOrbitSpeed;
	private Transform mOrbitAnchor;
	private Vector3 mOrbitDirection;
	private Vector3 mCubeMaxScale;

	public float mGrowingSpeed = 10f;
	public bool mIsCubeScaled = false;

	public int mCubeHealth = 100;
	private bool isAlive = true;

	private void cubeSetting(){
		mOrbitAnchor = Camera.main.transform;

		float x = Random.Range(-1f,1f);
		float y = Random.Range(-1f,1f);
		float z = Random.Range(-1f,1f);
		mOrbitDirection = new Vector3(x,y,z);

		mOrbitSpeed = Random.Range(5f, mOrbitMaxSpeed);

		float scale = Random.Range(mScaleMin, mScaleMax);
		mCubeMaxScale = new Vector3(scale,scale,scale);

		transform.localScale = Vector3.Lerp(
				transform.localScale, mCubeMaxScale, Time.deltaTime * mGrowingSpeed);
	}

	// Use this for initialization 
	void Start () {
		cubeSetting();
	}
	
	// Update is called once per frame
	void Update () {
		if(isAlive){
			RotateCube();	
		}
	}
	
	private void RotateCube(){
		transform.RotateAround(mOrbitAnchor.position, mOrbitDirection, mOrbitSpeed * Time.deltaTime);
		transform.Rotate(mOrbitDirection * 30 * Time.deltaTime);
	}

	public bool hit(int hitDamage){
		mCubeHealth -= hitDamage;

		if(mCubeHealth >= 0 && isAlive){
			StartCoroutine(destroyCube());
			return true;
		}
		return false;
	}

	private IEnumerator destroyCube(){
		isAlive = false;

		GetComponent<Renderer>().enabled = false;

		yield return new WaitForSeconds(1f);

		Destroy(gameObject);	
		Destroy(this);	
	}
}
