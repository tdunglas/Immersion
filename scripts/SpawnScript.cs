using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnScript : MonoBehaviour {

	public GameObject mCubeObj;
	public int mTotalCubes = 30;
	public float mTimeToSpawn = 1f;

	public GameObject[] mCubes;
	private bool mPositionSet = false;

	private IEnumerator SpawnLoop(){
		StartCoroutine(changePosition());

		yield return new WaitForSeconds(0.2f);

		int i = 0;
		while(i <= (mTotalCubes-1)){
			mCubes[i] = SpawnElement();
			i++;
			yield return new WaitForSeconds(
				Random.Range(mTimeToSpawn, mTimeToSpawn*3));
		}

	}

	private GameObject SpawnElement(){
		GameObject cube = Instantiate(mCubeObj, 
			(Random.insideUnitSphere*4) + transform.position, transform.rotation) as GameObject;
		float scale = Random.Range(0.5f,2f);

		while(scale == 0){
			scale = Random.Range(0.5f,2f);
		}

		cube.transform.localScale = new Vector3(scale,scale,scale);

		float r = Random.Range(0,1f);
		float g = Random.Range(0,1f);
		float b = Random.Range(0,1f);
		cube.GetComponent<Renderer>().material.color = new Color(r,g,b);
		
		return cube;
	}

	private IEnumerator changePosition(){
		yield return new WaitForSeconds(0.2f);

		if(!mPositionSet){
			if(VuforiaBehaviour.Instance.enabled){
				SetPosition();
			}
		}
	}

	private bool SetPosition(){
		Transform cam = Camera.main.transform;

		transform.position = cam.forward * 10;

		return true;
	}

	// Use this for initialization
	void Start () {
		mCubes = new GameObject[mTotalCubes];
		StartCoroutine(SpawnLoop());
	}
	
	// Up date is called once per frame
	void Update () {

		//Debug.Log(Camera.main.transform.position);	
	}
	
}
// ARPlIdz/////AAAAGfHEe1ZkDkxdv02j//upIdJtV1mWymBsTicohfHyGht97Fv57NnZpn86we9eAw5WHnz6ynS3HCGIVHfPjxgZTofrG+7CZlQPafisZsCWuRvcpkM2R3+OSmGVAHch2B0RROFL9b/cg93hMYQRDktUlxpTcAl6lTy+vN+Rtmt/mFmZDKLXzCaPLv/2bx2FjdR0m874J0Ei6nVKD8ZloH8YmhWAo3HEf2GefuEtDtWoWqN7esB69E72/5bYrYZIluFPDPReYBVuLwJ46i9D2Ty5peiZQ4FzidGoAaNdR74F7WlpPhy0pQQbtQe48eBZYMIBab3bRtK80b0PrLBkumO+/ANHzt0JwbGWUf0v4zDufnEG