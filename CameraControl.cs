using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public GameObject camera0,camera1,camera2,cameran;
	private int cam;

	void Start ()
	{
		cam = PlayerPrefs.GetInt("Room",0);
		Debug.Log("cam = "+cam);
			
		if(cam == 0)
		{
			cameran.transform.position = camera0.transform.position;
			cameran.transform.rotation = camera0.transform.rotation;
		}
		
		if(cam == 1)
		{
			cameran.transform.position = camera1.transform.position;
			cameran.transform.rotation = camera1.transform.rotation;
		}
		
		if(cam == 2)
		{
			cameran.transform.position = camera2.transform.position;
			cameran.transform.rotation = camera2.transform.rotation;
		}	
	}
		
	void Update () 
	{

	}
}
