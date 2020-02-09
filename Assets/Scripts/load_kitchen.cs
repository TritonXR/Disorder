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
  public GameObject instr_cup_L;
  public GameObject instr_cup_R;

  // Objects for moving test scene
  public GameObject l_mugParent;
  public GameObject l_mug1;
  public GameObject l_mug2;
  public GameObject l_mug3;
  public GameObject l_mug4;
  public GameObject l_mug5;
  public GameObject r_mugParent;
  public GameObject r_mug1;
  public GameObject r_mug2;
  public GameObject r_mug3;
  public GameObject r_mug4;
  public GameObject r_mug5;
  public GameObject left_ring;
  public GameObject right_ring;
  public GameObject platform;

  // Objects for finger-to-nose test
  public GameObject redbox1;
  public GameObject redbox2;
  public GameObject bluebox1;
  public GameObject bluebox2;


    // Use this for initialization
    void Start() {
    if (Data_tracker.currentScene == 1)
    {
      hands.SetActive(true);
      instruction1.SetActive(true);
    }


    else if (Data_tracker.currentScene == 2) // Cutting test L
    {
      island.SetActive(true);
      foods_left.SetActive(true);
      knife_left.SetActive(true);
      cuttingboard.SetActive(true);
      instructionL.SetActive(true);
    }
    else if (Data_tracker.currentScene == 3) // Cutting test R
    {
      island.SetActive(true);
      foods_right.SetActive(true);
      knife_right.SetActive(true);
      cuttingboard.SetActive(true);
      instructionR.SetActive(true);
    }
    else if (Data_tracker.currentScene == 4) // mug test L
    {
        island.SetActive(true);
        l_mugParent.SetActive(true);
        l_mug1.SetActive(true);
        l_mug2.SetActive(true);
        l_mug3.SetActive(true);
        l_mug4.SetActive(true);
        l_mug5.SetActive(true);
        left_ring.SetActive(true);
        right_ring.SetActive(true);
        instr_cup_L.SetActive(true);
        platform.SetActive(true);
    }
    else if(Data_tracker.currentScene == 5) //mug test R
    {
        island.SetActive(true);
        r_mugParent.SetActive(true);
        r_mug1.SetActive(true);
        r_mug2.SetActive(true);
        r_mug3.SetActive(true);
        r_mug4.SetActive(true);
        r_mug5.SetActive(true);
        right_ring.SetActive(true);
        left_ring.SetActive(true);
        instr_cup_R.SetActive(true);
        platform.SetActive(true);
        }

    else if (Data_tracker.currentScene == 6) //finger-nose-test
        {


        }
    else if (Data_tracker.currentScene == 7) // same as Scene '1' but with Leap Motion
        {
            hands.SetActive(true);
            instruction1.SetActive(true); // Need to change isntructions displayed; remove 'controllers' ######
        }
  }
	// Update is called once per frame
	void Update () {
		
	}
}
