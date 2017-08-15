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
  public GameObject l_mug1;
  public GameObject l_mug2;
  public GameObject l_mug3;
  public GameObject l_mug4;
  public GameObject l_mug5;
  public GameObject r_mug1;
  public GameObject r_mug2;
  public GameObject r_mug3;
  public GameObject r_mug4;
  public GameObject r_mug5;
  public GameObject left_ring;
  public GameObject right_ring;
  public GameObject beaker;
  public GameObject spout;

  // Use this for initialization
  void Start() {
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
    else if (Data_tracker.currentScene == 4)
    {
      island.SetActive(true);
      r_mug1.SetActive(true);
      r_mug2.SetActive(true);
      r_mug3.SetActive(true);
      r_mug4.SetActive(true);
      r_mug5.SetActive(true);
      right_ring.SetActive(true);
      left_ring.SetActive(true);
      beaker.SetActive(true);
      spout.SetActive(true);
    }
    else if(Data_tracker.currentScene == 5)
    {
      island.SetActive(true);
      l_mug1.SetActive(true);
      l_mug2.SetActive(true);
      l_mug3.SetActive(true);
      l_mug4.SetActive(true);
      l_mug5.SetActive(true);
      left_ring.SetActive(true);
      right_ring.SetActive(true);
      beaker.SetActive(true);
      spout.SetActive(true);
    }
  }
	
	// Update is called once per frame
	void Update () {
		
	}
}
