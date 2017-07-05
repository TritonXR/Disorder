using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_kitchen : MonoBehaviour {
  public GameObject island;

  // Objects for tremor test scene
  public GameObject instruction1;
  public GameObject hands;

  // Objects for cutting scene
  public GameObject foods;
  public GameObject knife;
  public GameObject cuttingboard;
  public GameObject instruction2;

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
      foods.SetActive(true);
      knife.SetActive(true);
      cuttingboard.SetActive(true);
      instruction2.SetActive(true);
    }
    else if (Data_tracker.currentScene == 3)
    {
      island.SetActive(true);
      mug.SetActive(true);
      waterboiler.SetActive(true);
    }
  }
	
	// Update is called once per frame
	void Update () {
		
	}
}
