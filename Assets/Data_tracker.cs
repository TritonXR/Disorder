using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;

public class Data_tracker : MonoBehaviour
{
    //File to record the data
    public StreamWriter file;

    //Movement of head and both hands
    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject knife;

    //Timer
    private float startTime;
    private float totalTime;
    private bool started = false;
    private bool finished = false;

    void Start()
    {
        //TODO need to add the user name to the file
        file = new StreamWriter("data.txt");
        file.WriteLine("Time | Head x y z rotx roty rotz | Left Hand x y z rotx roty rotz | Right Hand x y z rotx roty rotz");
        startTime = Time.time;
        StartCoroutine(RecordData());
    }

    void Update()
    {
        // if knife is grabbed, started = true?

        if (finished)
            return;

        totalTime = Time.time - startTime;
    }

    IEnumerator RecordData()
    {
        while (true)
        {
            //if (started)
            //{
            file.WriteLine(head.transform.position + " " + head.transform.rotation.eulerAngles + "|" +
            leftHand.transform.position + " " + leftHand.transform.rotation.eulerAngles + "|" +
            rightHand.transform.position + " " + rightHand.transform.rotation.eulerAngles);
            //}
            yield return new WaitForSeconds(.1f);
        }
    }

    public void Finish()
    {
        file.WriteLine(totalTime.ToString("f2") + head.transform.position + " " + head.transform.rotation.eulerAngles + "|" +
                leftHand.transform.position + " " + leftHand.transform.rotation.eulerAngles + "|" +
                rightHand.transform.position + " " + rightHand.transform.rotation.eulerAngles);
        finished = true;
    }
}