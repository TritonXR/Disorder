using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;

public class Timer : MonoBehaviour
{
    //File to record the data
    public StreamWriter file;

    //Movement of head and both hands
    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;

    //Timer
	private float startTime;
	private float totalTime;
	private bool finnished = false;

	void Start ()
	{
		//TODO need to add the user name to the file
		file = new StreamWriter("data.txt");
		file.WriteLine("Time | Head x y z rotx roty rotz | Left Hand x y z rotx roty rotz | Right Hand x y z rotx roty rotz");
		startTime = Time.time;
		StarCoroutine( RecordData() );
	}

	void Update ()
	{
		if(finnished)
			return;

		totalTime = Time.time - startTime;
	}

	IEnumerator RecordData()
	{
		while(true)
		{
			file.WriteLine(head.transform.position+" "+head.transform.rotation.eulerAngles+"|"+
				leftHand.transform.position+" "+leftHand.transform.rotation.eulerAngles+"|"+
				rightHand.transform.position+" "+rightHand.transform.rotation.eulerAngles);
			yield return new WaitForSecond(.1f);
		}
	}

	public void Finish()
	{
		file.WriteLine(totalTime.ToString("f2")+head.transform.position+" "+head.transform.rotation.eulerAngles+"|"+
				leftHand.transform.position+" "+leftHand.transform.rotation.eulerAngles+"|"+
				rightHand.transform.position+" "+rightHand.transform.rotation.eulerAngles);
		finnished = true;
	}
}