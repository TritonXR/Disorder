using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCube : MonoBehaviour {

    public GameObject cube;
    public float sec = 5f;

	// Use this for initialization
	void Start () {
        cube.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       // cube.SetActive(true);
	}

    IEnumerator disappear()
    {
        yield return new WaitForSeconds(sec);
        cube.SetActive(true);
    }
}
