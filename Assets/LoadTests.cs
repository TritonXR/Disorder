using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTests : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void onTriggerEnter(Collider other)
  {
    if(other.gameObject.GetComponent<uniquescript>() != null )
    {
      SceneManager.LoadScene(1);
    }
  }
}
