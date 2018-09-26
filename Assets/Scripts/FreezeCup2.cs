using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FreezeCup2 : MonoBehaviour {

    public GameObject camera;
	public Rigidbody m_Rigidbody;
	private VRTK.Examples.Sword anotherScript;
	public bool stuck;
	public int counter;
	public int roundCounter;
	public GameObject tableTop;
    public int cylinder_counter = 0;

    //File to record the data
    public StreamWriter file;
    private String filename;

    // Use this for initialization
    void Start () {
		stuck = false;
		m_Rigidbody = GetComponent<Rigidbody>();
		anotherScript = GetComponent<VRTK.Examples.Sword>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (counter > 0)
		{
			anotherScript.isGrabbable = false;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log ("counter = " + counter);
		if (other.gameObject.tag == "OtherSection2") {
			counter++;
            cylinder_counter = 0;
            foreach (Transform child in transform.Find("Coffee_Set"))
            {
                if (child.gameObject.activeSelf)
                    cylinder_counter++;
            }
            Debug.Log("cylinder_counter: " + cylinder_counter);
            if (camera.GetComponent<mug_filename_tracker>().mug_data_filename == "")
            {
                filename = "mugdata_right_" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".txt";
                camera.GetComponent<mug_filename_tracker>().mug_data_filename = filename;
            }
            else
            {
                filename = camera.GetComponent<mug_filename_tracker>().mug_data_filename;
            }
            file = new StreamWriter(filename);
            file.WriteLine(cylinder_counter + ", ");
        }
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("GameController"))
		{
			stuck = true;
		}

		/*if (transform.position.x < -1 && transform.position.x > -2)
        {
            if (transform.position.z < 0 && transform.position.z > -0.5)
            {
                if (transform.position.y < 1.34 && transform.position.y > 1.36)
                {
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
                    m_Rigidbody.useGravity = false;
                    anotherScript.isGrabbable = false;
                    stuck = true;
                    Debug.Log("It's WORKING");
                }
            }
        }*/
	}
}
