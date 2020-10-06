using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour 
{
	public GameObject cameran;
	private bool bt1 = false;
	private float speed = 100f;
	
	void Start()
    {
		PlayerPrefs.SetInt("Button",1);
	}
	
	public void OnGUI()     //OnGUI方法的使用
	{
		GUI.skin.button.normal.textColor = new Color (128,128,128);
		GUI.skin.button.fontSize = 80;
		
		if (PlayerPrefs.GetInt("Button",0) == 1)
		{
			if(GUI.RepeatButton ( new Rect (50,1100,200,100),"Left"))  //注意相关的参数
			{
				cameran.transform.Rotate(Vector3.up * Time.deltaTime * -speed);
				// bt1 = true;
			}
			if(GUI.RepeatButton (new Rect (2438,1100,200,100),"Right"))
			{
				cameran.transform.Rotate(Vector3.up * Time.deltaTime * speed);
			}
		}
	}
	
	// public void update()
	// {
		// if(bt1 = true)
		// {
			// Debug.Log("1");
			// Quaternion startRotation = transform.rotation; //开始点
			// Vector3 endRotation = new Vector3(0,90,0); //结束点
			// float t = 0; //旋转时间
			// while(t<1)
			// {
			// t+= Time.deltaTime;//这样会在一秒钟左右旋转到位
			// transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(endRotation),t);
			// }
		// }
	// }
}