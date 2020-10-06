using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadSe : MonoBehaviour
{
	private int tMask1,tMask2,tMask3,tMask4,tMask5,tMask6,tMask7,tMask8,tMask9,tMask0;
	private string pass;
	private int Np = 0;
	public string PadNum;
	public string Password;
	public GameObject DoorOld,DoorNew,Leave,Close;
    // Start is called before the first frame update
    void Start()
    {
        pass = "";
    }

    // Update is called once per frame
    void Update()
    {	
		if (PlayerPrefs.GetInt(PadNum,0) == 1 )
		{
		// Debug.Log("clickable");
			if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        	{
            	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            	RaycastHit hitInfo;
				tMask1 = LayerMask.GetMask("B1");
				tMask2 = LayerMask.GetMask("B2");
				tMask3 = LayerMask.GetMask("B3");
				tMask4 = LayerMask.GetMask("B4");
				tMask5 = LayerMask.GetMask("B5");
				tMask6 = LayerMask.GetMask("B6");
				tMask7 = LayerMask.GetMask("B7");
				tMask8 = LayerMask.GetMask("B8");
				tMask9 = LayerMask.GetMask("B9");
				tMask0 = LayerMask.GetMask("B0");
			
            	if (Physics.Raycast(ray, out hitInfo, 10f, tMask1))
            	{
					pass += "1";
					Debug.Log("pass = "+pass);
					Np++;
				}
			
				if (Physics.Raycast(ray, out hitInfo, 10f, tMask2))
            	{
					pass += "2";
					Debug.Log("pass = "+pass);
					Np++;
				}
			
				if (Physics.Raycast(ray, out hitInfo, 10f, tMask3))
            	{
					pass += "3";
					Debug.Log("pass = "+pass);
					Np++;
				}
				
				if (Physics.Raycast(ray, out hitInfo, 10f, tMask4))
	            {
					pass += "4";
					Debug.Log("pass = "+pass);
					Np++;
				}
				
				if (Physics.Raycast(ray, out hitInfo, 10f, tMask5))
	            {
					pass += "5";
					Debug.Log("pass = "+pass);
					Np++;
				}
				
				if (Physics.Raycast(ray, out hitInfo, 10f, tMask6))
	            {
					pass += "6";
					Debug.Log("pass = "+pass);
					Np++;
				}
				
				if (Physics.Raycast(ray, out hitInfo, 10f, tMask7))
	            {
					pass += "7";
					Debug.Log("pass = "+pass);
					Np++;
				}
				
				if (Physics.Raycast(ray, out hitInfo, 10f, tMask8))
	            {
					pass += "8";
					Debug.Log("pass = "+pass);
					Np++;
				}
				
				if (Physics.Raycast(ray, out hitInfo, 10f, tMask9))
	            {
					pass += "9";
					Debug.Log("pass = "+pass);
					Np++;
				}
				
				if (Physics.Raycast(ray, out hitInfo, 10f, tMask0))
	            {
					pass += "0";
					Debug.Log("pass = "+pass);
					Np++;
				}
				
				if (Np >= 1)
				{
					if (pass == Password)
					{
						Debug.Log("Corect");
						DoorOld.GetComponent<MeshRenderer>().enabled = !DoorOld.GetComponent<MeshRenderer>().enabled;
						DoorNew.GetComponent<MeshRenderer>().enabled = !DoorNew.GetComponent<MeshRenderer>().enabled;
						Leave.GetComponent<BoxCollider>().enabled = !Leave.GetComponent<BoxCollider>().enabled;
						Close.SetActive(false);
						
					}
					else
					{
						Debug.Log("Wrong");
					}
					Np = 0;
					pass = "";
				}
			
			
			}
		}
		else
		{	
			Np = 0;
			pass = "";
		}
    }
}
