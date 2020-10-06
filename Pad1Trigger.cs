using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pad1Trigger : MonoBehaviour
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
	private Vector3 OldCamPos;
	private Quaternion OldCamRot;
	public GameObject ColliderBox;
	private bool ZoomIn = false;
	public string PadNum;
	public int Room;
	

    // Use this for initialization
    void Start()
    {	
		cv4.x = 0f; cv4.y = 0f; cv4.z = 0f; cv4.w = 0f;
		tMask = LayerMask.GetMask(MaskName);
		 // tMask = 1;
		 // Debug.Log("tMask = " + tMask);
		rc = GameObject.Find("mCam"); 
		RCamera = rc.GetComponent<Camera>();

		PlayerPrefs.SetInt(PadNum,0);
		// Debug.Log("camera = " + RCamera);
		// Debug.Log("tMask = " + tMask);
    }

    // Update is called once per frame
    void Update()
    {	
		// 射线检测碰撞物体
        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 10f, tMask) && PlayerPrefs.GetInt("Room",0) == Room)
            {
				OldCamPos = RCamera.transform.position;
				OldCamRot = RCamera.transform.rotation;
				ZoomInMov = true;
            	Debug.Log("click trigger " + MaskName +Room);
			}
		}
		
		// 点到物体放大
		if (ZoomInMov == true)
		{	
			PlayerPrefs.SetInt("Button",0);
			if ((RCamera.transform.position != nc.transform.position && RCamera.transform.rotation != nc.transform.rotation )|| th < 9 * Stime)
			{
				// Debug.Log("isM = " + isM);
				RCamera.transform.position=Vector3.SmoothDamp(RCamera.transform.localPosition, nc.transform.localPosition, ref cv, Stime);
				RCamera.transform.rotation = new Quaternion ( Mathf.SmoothDamp(RCamera.transform.rotation.x, nc.transform.rotation.x, ref cv4.x, Stime),Mathf.SmoothDamp( RCamera.transform.rotation.y, nc.transform.rotation.y, ref cv4.y, Stime),Mathf.SmoothDamp( RCamera.transform.rotation.z, nc.transform.rotation.z, ref cv4.z, Stime),Mathf.SmoothDamp(RCamera.transform.rotation.w, nc.transform.rotation.w, ref cv4.w, Stime));
				
				// Debug.Log("cv = " + cv);
				th += Time.deltaTime;
				// Debug.Log("RCamera.transform.rotation = " + RCamera.transform.rotation);
			}
			else
			{
				ZoomInMov = false;
				// Debug.Log("ZoomInMov = " + ZoomInMov);
				ZoomIn = true;
				th = 0f;
				ColliderBox.GetComponent<BoxCollider>().enabled = !ColliderBox.GetComponent<BoxCollider>().enabled;
				PlayerPrefs.SetInt(PadNum,1);
				// Debug.Log (box.GetComponent<BoxCollider>().enabled);
			}
		}
		
		// 点返回缩小
		if (ZoomOutMov == true)
		{
			PlayerPrefs.SetInt(PadNum,0);
			if ((RCamera.transform.position != OldCamPos && RCamera.transform.rotation != OldCamRot )|| th < 9 * Stime)
			{
				// Debug.Log("Move");
				// Debug.Log("isM = " + isM);
				RCamera.transform.position=Vector3.SmoothDamp(RCamera.transform.localPosition, OldCamPos, ref cv, Stime);
				RCamera.transform.rotation = new Quaternion ( Mathf.SmoothDamp(RCamera.transform.rotation.x, OldCamRot.x, ref cv4.x, Stime),Mathf.SmoothDamp( RCamera.transform.rotation.y, OldCamRot.y, ref cv4.y, Stime),Mathf.SmoothDamp( RCamera.transform.rotation.z, OldCamRot.z, ref cv4.z, Stime),Mathf.SmoothDamp(RCamera.transform.rotation.w, OldCamRot.w, ref cv4.w, Stime));
				
				// Debug.Log("cv = " + cv);
				th += Time.deltaTime;
				// Debug.Log("RCamera.transform.rotation = " + RCamera.transform.rotation);
			}
			else
			{
				ZoomOutMov = false;
				// Debug.Log("ZoomInMov = " + ZoomInMov);
				th = 0f;
				ColliderBox.GetComponent<BoxCollider>().enabled = !ColliderBox.GetComponent<BoxCollider>().enabled;
				PlayerPrefs.SetInt("Button",1);
				// Debug.Log (box.GetComponent<BoxCollider>().enabled);
			}
		}
			
    }

	public void OnGUI()     //OnGUI方法的使用
	{ 
		if (ZoomIn == true)
				{
					if(GUI.RepeatButton ( new Rect (1244,42,200,100),"Back"))  //注意相关的参数
						{
							ZoomOutMov = true;
							ZoomIn = false;
						}
				}
	}

}