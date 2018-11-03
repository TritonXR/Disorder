using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FreezeCup2 : MonoBehaviour
{

    public GameObject camera;
    public Rigidbody m_Rigidbody;
    private VRTK.Examples.Sword anotherScript;
    public bool stuck;
    public int counter;
    public int roundCounter;
    public GameObject tableTop;
    public int cylinder_counter = 0;
    public GameObject rightParent;
    private List<int> coffeeCounters;
    private leftMugs rightMugsScript;

    // Use this for initialization
    void Start()
    {
        stuck = false;
        m_Rigidbody = GetComponent<Rigidbody>();
        anotherScript = GetComponent<VRTK.Examples.Sword>();
        rightMugsScript = rightParent.GetComponent<leftMugs>();
        coffeeCounters = rightMugsScript.coffeeCounters;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0)
        {
            anotherScript.isGrabbable = false;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "OtherSection")
        {
            counter++;
            //Debug.Log("counter = " + counter);
            cylinder_counter = 0;

            foreach (Transform child in transform.Find("Coffee_Set"))
            {
                if (child.gameObject.activeSelf)
                    cylinder_counter++;
            }
            coffeeCounters.Add(cylinder_counter);
            rightMugsScript.updateCounter(cylinder_counter);

            if (coffeeCounters.Count == 5)
            {
                rightMugsScript.writeToFile();
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            stuck = true;
        }

    }
}
