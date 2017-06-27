using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGyroscopeControllerImmersion : MonoBehaviour {

	
	private bool gyroEnabled = true;
    private const float lowPassFilterFactor = 0.2f;
     
    private readonly Quaternion baseIdentity =  Quaternion.Euler(90, 0, 0);
    private readonly Quaternion landscapeRight =  Quaternion.Euler(0, 0, 90);
    private readonly Quaternion landscapeLeft =  Quaternion.Euler(0, 0, -90);
    private readonly Quaternion upsideDown =  Quaternion.Euler(0, 0, 180);
     
    private Quaternion cameraBase =  Quaternion.identity;
    private Quaternion calibration =  Quaternion.identity;
    private Quaternion baseOrientation =  Quaternion.Euler(90, 0, 0);
    private Quaternion baseOrientationRotationFix =  Quaternion.identity;
     
    private Quaternion referanceRotation = Quaternion.identity;
    /*
	private bool debug = true;

    public int score;
    public int levelSore = 5;
    public float timeEnd;
    public float timeLeft;
    public float timeValue = 30f;
	*/
    protected void Start () 
    {
        AttachGyro();
        //timeEnd = Time.time + timeValue;
		
		Input.gyro.enabled = true;
        AttachGyro();
    }
     
    protected void Update() 
    {
        if (!gyroEnabled)
            return;
        
        transform.rotation = Quaternion.Slerp(transform.rotation,
                               	cameraBase * ( ConvertRotation
                               		(referanceRotation * Input.gyro.attitude) * GetRotFix()),
                               	 lowPassFilterFactor);
    	
    	// want to fasten rotation from left to right and the contrary
        float valx = transform.rotation.x * 100;
        float valy = transform.rotation.y * 400; // should be the one
        float valz = transform.rotation.z * 100;

        Camera.main.transform.rotation = Quaternion.Euler(valx, valy, valz);
        /*
        timeLeft = timeEnd - Time.time;
        if(timeLeft <= 0 && score < levelSore){
            SceneManager.LoadScene("sceneGameOver");
        }

        else if(timeLeft <= 0 && score >= levelSore){
            SceneManager.LoadScene("sceneWinGame");
        }
		*/
    }
     /*
    protected void OnGUI()
    {
        if (!debug)
            return;

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

        Input.gyro.enabled = true;
        AttachGyro();
    }
     */
    //Attaches gyro controller to the transform.

    public void AttachGyro()
    {
        gyroEnabled = true;

        ResetBaseOrientation();
        UpdateCalibration(true);
        UpdateCameraBaseRotation(true);
        RecalculateReferenceRotation();
    }
     
    //Detaches gyro controller from the transform

    private void DetachGyro()
    {
        gyroEnabled = false;
    }

    //Update the gyro calibration.

    private void UpdateCalibration(bool onlyHorizontal)
    {
        if (onlyHorizontal)
        {
            var fw = (Input.gyro.attitude) * (-Vector3.forward);
            fw.z = 0;
            if (fw == Vector3.zero)
            {
                calibration = Quaternion.identity;
            }
            else
            {
                calibration = (Quaternion.FromToRotation(baseOrientationRotationFix * Vector3.up, fw));
            }
        }
        else
        {
            calibration = Input.gyro.attitude;
        }
    }

    //Update the camera base rotation.

    //Only y rotation.
    private void UpdateCameraBaseRotation(bool onlyHorizontal)
    {
        if (onlyHorizontal)
        {
            var fw = transform.forward;
            fw.y = 0;
            if (fw == Vector3.zero)
            {
                cameraBase = Quaternion.identity;
            }
            else
            {
                cameraBase = Quaternion.FromToRotation(Vector3.forward, fw);
            }
        }
        else
        {
            cameraBase = transform.rotation;
        }
    }
     

    //Converts the rotation from right handed to left handed.

    //<returns>
    //The result rotation.
    //</returns>
    //<param name='q'>
    //The rotation to convert.
    //</param>
    private static Quaternion ConvertRotation(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);    
    }
     

    //Gets the rot fix for different orientations.

    //<returns>
    //The rot fix.
    //</returns>
    private Quaternion GetRotFix()
    {
        //#if UNITY_3_5
        if (Screen.orientation == ScreenOrientation.Portrait)
            return Quaternion.identity;
         
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.Landscape)
            return landscapeLeft;
         
        if (Screen.orientation == ScreenOrientation.LandscapeRight)
            return landscapeRight;
         
        if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            return upsideDown;
        return Quaternion.identity;
        //#else
        //return Quaternion.identity;
        //#endif
    }
     
    //Recalculates reference system.

    private void ResetBaseOrientation()
    {
        baseOrientationRotationFix = GetRotFix();
        baseOrientation = baseOrientationRotationFix * baseIdentity;
    }
     
    //Recalculates reference rotation.

    private void RecalculateReferenceRotation()
    {
        referanceRotation = Quaternion.Inverse(baseOrientation)*Quaternion.Inverse(calibration);
    }
}