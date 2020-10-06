using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnLoginButtonClick()
	{
		PlayerPrefs.SetInt("Room",0);
		SceneManager.LoadScene("HouseFoundation");
	}
}
