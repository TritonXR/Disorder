using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_kitchen : MonoBehaviour {
  public GameObject island;

  // Objects for tremor test scene
  public GameObject instruction1;
  public GameObject hands;

  // Objects for cutting scene
  public GameObject foods_left;
  public GameObject foods_right;
  public GameObject knife_left;
  public GameObject knife_right;
  public GameObject cuttingboard;
  public GameObject instructionR;
  public GameObject instructionL;

  // Objects for moving test scene
  public GameObject mug;
  public GameObject waterboiler;

	// Use this for initialization
	void Start () {
    if (Data_tracker.currentScene == 1)
    {
      hands.SetActive(true);
      instruction1.SetActive(true);
    }
    else if (Data_tracker.currentScene == 2)
    {
      island.SetActive(true);
      foods_left.SetActive(true);
      knife_left.SetActive(true);
      cuttingboard.SetActive(true);
      instructionL.SetActive(true);
    }
    else if (Data_tracker.currentScene == 3)
    {
      island.SetActive(true);
      foods_right.SetActive(true);
      knife_right.SetActive(true);
      cuttingboard.SetActive(true);
      instructionR.SetActive(true);
    }
  }
	
	// Update is called once per frame
	void Update () {
		
	}
}
