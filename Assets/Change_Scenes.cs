using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("0"))
    {
      SceneManager.LoadScene(0);
    }
    if (Input.GetKeyDown("1"))
    {
      SceneManager.LoadScene(1);
    }
    if (Input.GetKeyDown("2"))
    {
      SceneManager.LoadScene(2);
    }
    if (Input.GetKeyDown("3"))
    {
      SceneManager.LoadScene(3);
    }
  }
}
