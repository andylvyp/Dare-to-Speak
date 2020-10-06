using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LeaveRoom : MonoBehaviour
{
	private Camera RCamera;
	private int cam,tMask;
	public string MaskName;
	private GameObject rc;
	public GameObject nc;
	private float Stime = 0.3f;
	private Vector3 cv = Vector3.zero;
	private Quaternion cv4; 
	private bool ZoomInMov = false;
	private bool ZoomOutMov = false;
	private float th = 0f;
	private Quaternion OldCamRot;
	private bool ZoomIn = false;
	public int OldRoom,NewRoom;
	private Vector3 oldPos;
	private Quaternion oldRot;
	private bool changecam = false;
	

    // Use this for initialization
    void Start()
    {	
		cv4.x = 0f; cv4.y = 0f; cv4.z = 0f; cv4.w = 0f;
		tMask = LayerMask.GetMask(MaskName);
		
		rc = GameObject.Find("mCam"); 
		RCamera = rc.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		// 射线检测碰撞物体
        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {
			// Debug.Log("1");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
			// Debug.Log("Button Down" + ray);
			// Debug.Log(+PlayerPrefs.GetInt("Camera",0)+Room);
			// Debug.Log("Camera="+PlayerPrefs.GetInt("Camera",0)+ " Room=" + Room);
            if (Physics.Raycast(ray, out hitInfo, 10f, tMask) && PlayerPrefs.GetInt("Room",0) == OldRoom)
            {
				// Debug.Log("peng");
				ZoomInMov = true;
				oldPos = RCamera.transform.position;
				oldRot = RCamera.transform.rotation;
            	Debug.Log("click trigger");			
			}
		}
		
		// 点到物体放大
		if (ZoomInMov == true)
		{	
			// Debug.Log("cam = "+cam);
			if ((RCamera.transform.position != nc.transform.position && RCamera.transform.rotation != nc.transform.rotation ) && th < 9 * Stime)
			{
				// Debug.Log("isM = " + isM);
				RCamera.transform.position=Vector3.SmoothDamp(RCamera.transform.localPosition, nc.transform.localPosition, ref cv, Stime);
				RCamera.transform.rotation = new Quaternion ( Mathf.SmoothDamp(RCamera.transform.rotation.x, nc.transform.rotation.x, ref cv4.x, Stime),Mathf.SmoothDamp( RCamera.transform.rotation.y, nc.transform.rotation.y, ref cv4.y, Stime),Mathf.SmoothDamp( RCamera.transform.rotation.z, nc.transform.rotation.z, ref cv4.z, Stime),Mathf.SmoothDamp(RCamera.transform.rotation.w, nc.transform.rotation.w, ref cv4.w, Stime));
				
				// Debug.Log("cv = " + cv);
				th += Time.deltaTime;
				// Debug.Log("Time="+th);
				// Debug.Log("RCamera.transform.rotation = " + RCamera.transform.rotation);
			}
			else
			{
				// Debug.Log("ZoomInMov = " + ZoomInMov);
				th = 0f;
				// Debug.Log("Time clear="+th);
				PlayerPrefs.SetInt("Room",NewRoom);
				ZoomInMov = false;
				// Debug.Log (box.GetComponent<BoxCollider>().enabled);
			}
		}
			
    }
}