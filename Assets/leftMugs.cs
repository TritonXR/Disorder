using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class leftMugs : MonoBehaviour {
    public List<int> coffeeCounters;
    public GameObject[] mugs;
    //File to record the data
    private StreamWriter file;
    public string direction;
    private String filename;
    private String text;

    // Use this for initialization
    void Start ()
    {
        coffeeCounters = new List<int>();
        filename = "mugdata_" + direction + "_" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".txt";
        text = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void writeToFile()
    {
        if (file == null)
        {
            file = new StreamWriter(filename, true);
            file.AutoFlush = true;
        }

        file.Flush();
        file.Write(text);
        //Debug.Log("cylinder_counter: " + cylinder_counter);
        file.Close();
    }

    public void updateCounter(int cylinder_counter)
    {
        text += cylinder_counter.ToString() + ", ";
        coffeeCounters.Add(cylinder_counter);
        Debug.Log(coffeeCounters.Count);
        if(coffeeCounters.Count == 5)
        {
            writeToFile();
        }
        //Debug.Log(text);
    }
}
