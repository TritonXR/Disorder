using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class Data_tracker : MonoBehaviour
{
    //File to record the data
    public StreamWriter file;
	private String filename;

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
    public int counter = 0;

    void Start()
    {
        //TODO need to add the user name to the file
		filename = "data_" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".txt";
        file = new StreamWriter(filename);
        file.WriteLine("Time\tHead\tx\ty\t\tz\trotx\troty\trotz\tLeft Hand\tx\ty\tz\trotx\troty\trotz\tRight Hand\tx\ty\tz\trotx\troty\trotz\n");
        startTime = Time.time;
        StartCoroutine(RecordData());
    }

    void Update()
    {
        // if knife is grabbed, started = true?

        if (finished)
            return;

        totalTime = Time.time - startTime;
        //Debug.Log(totalTime);
    }

    IEnumerator RecordData()
    {
        while (true)
        {
            //Debug.Log(totalTime.ToString());
            //if (started)
            //{
			file.WriteLine(totalTime.ToString() + "\tx\t" + head.transform.position.x + "\t" + head.transform.position.y + "\t" + head.transform.position.z + "\tx\t"
				+ head.transform.rotation.eulerAngles.x + "\t" + head.transform.rotation.eulerAngles.y + "\t" + head.transform.rotation.eulerAngles.z + "\t" 
				+ leftHand.transform.position.x + "\t" + leftHand.transform.position.y + "\t" + leftHand.transform.position.z + "\tx\t"
				+ leftHand.transform.rotation.eulerAngles.x + "\t" + leftHand.transform.rotation.eulerAngles.y + "\t" + leftHand.transform.rotation.eulerAngles.z + "\t"
				+ rightHand.transform.position.x + "\t" + rightHand.transform.position.y + "\t" + rightHand.transform.position.z + "\tx\t"
				+ rightHand.transform.rotation.eulerAngles.x + "\t" + rightHand.transform.rotation.eulerAngles.y + "\t" + rightHand.transform.rotation.eulerAngles.z + "\t\n");
            //}
            yield return new WaitForSeconds(.1f);
        }
    }

    public void Finish()
    {
		file.WriteLine(totalTime.ToString("f2") + "\tx\t" + head.transform.position.x + "\t" + head.transform.position.y + "\t" + head.transform.position.z + "\tx\t"
			+ head.transform.rotation.eulerAngles.x + "\t" + head.transform.rotation.eulerAngles.y + "\t" + head.transform.rotation.eulerAngles.z + "\t" 
			+ leftHand.transform.position.x + "\t" + leftHand.transform.position.y + "\t" + leftHand.transform.position.z + "\tx\t"
			+ leftHand.transform.rotation.eulerAngles.x + "\t" + leftHand.transform.rotation.eulerAngles.y + "\t" + leftHand.transform.rotation.eulerAngles.z + "\t"
			+ rightHand.transform.position.x + "\t" + rightHand.transform.position.y + "\t" + rightHand.transform.position.z + "\tx\t"
			+ rightHand.transform.rotation.eulerAngles.x + "\t" + rightHand.transform.rotation.eulerAngles.y + "\t" + rightHand.transform.rotation.eulerAngles.z + "\t\n");

        file.Close();
        finished = true;
    }
}