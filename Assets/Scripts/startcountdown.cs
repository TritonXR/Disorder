using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class startcountdown : MonoBehaviour {
  public GameObject countdown;
  public GameObject instruction;
  private TextMesh countdown_textm;
  private TextMesh inst_textm;
  private int count1;
  private int count2;
  private int flag;
  private bool startTiming;

  //File to record the data
  public StreamWriter file1;
  private String filename1;
  public StreamWriter file2;
  private String filename2;

  //Movement of head and both hands
  public GameObject head;
  public GameObject leftHand;
  public GameObject rightHand;

  //Timer
  private float startTime;
  private float totalTime;
  private bool started = false;
  private bool finished = false;
  public int counter = 0;

  // Use this for initialization
  void Start () {
    count1 = 10;
    count2 = 10;
    countdown_textm = countdown.GetComponent<TextMesh>();
    inst_textm = instruction.GetComponent<TextMesh>();
    flag = 0;

    filename1 = "tremortestUP_" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".txt";
    file1 = new StreamWriter(filename1);
    file1.WriteLine("Time\thead_x\thead_y\thead_z\thead_rotx\thead_roty\thead_rotz\t" +
          "left_x\tleft_y\tleft_z\tleft_rotx\tleft_roty\tleft_rotz\tright_x\tright_y\tright_z\tright_rotx\tright_roty\tright_rotz\n");

    filename2 = "tremortestDOWN_" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".txt";
    file2 = new StreamWriter(filename2);
    file2.WriteLine("Time\thead_x\thead_y\thead_z\thead_rotx\thead_roty\thead_rotz\t" +
          "left_x\tleft_y\tleft_z\tleft_rotx\tleft_roty\tleft_rotz\tright_x\tright_y\tright_z\tright_rotx\tright_roty\tright_rotz\n");

    startTiming = false;
  }
	
	// Update is called once per frame
	void Update () {
    if (startTiming)
    {
      totalTime = Time.time - startTime;
    } else
    {
      totalTime = 0f;
    }
  }

  /*private void OnControllerColliderHit(ControllerColliderHit hit)
  {
    if (hit.collider.gameObject.GetComponent<right_controller_unique>() != null)
    {
      Debug.Log("Collision detected from script");
    }
    Debug.Log("Collision detected");
    StartCoroutine(count_down());
  }*/

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.GetComponent<right_controller_unique>() != null && flag == 0)
    {
      Debug.Log("Collision detected from script");
      StartCoroutine(count_down());
      flag = 1;
    }    
  }

  IEnumerator count_down()
  {
    startTime = Time.time;
    startTiming = true;
    while (count1 > -1)
    {
      StartCoroutine(RecordData1());
      yield return new WaitForSeconds(1f);
      countdown_textm.text = count1.ToString();
      count1--;
    }
    startTiming = false;
    countdown_textm.text = "Done!";

    yield return new WaitForSeconds(1f);
    inst_textm.text = "Hold your controllers in your lap for 10 seconds...";
    countdown_textm.text = "";
    yield return new WaitForSeconds(3f);

    startTime = Time.time;
    startTiming = true;
    while (count2 > -1)
    {
      StartCoroutine(RecordData2());
      yield return new WaitForSeconds(1f);
      countdown_textm.text = count2.ToString();
      count2--;
    }

    countdown_textm.text = "Done!";

    yield return new WaitForSeconds(4f);
    SceneManager.LoadScene(0);
  }

  IEnumerator RecordData1()
  {
    while (count1 > -1)
    {
      //Debug.Log(totalTime.ToString());
      //if (started)
      //{
      file1.WriteLine(totalTime.ToString() + "\t" + head.transform.position.x + "\t" + head.transform.position.y + "\t" + head.transform.position.z + "\t"
        + head.transform.rotation.eulerAngles.x + "\t" + head.transform.rotation.eulerAngles.y + "\t" + head.transform.rotation.eulerAngles.z + "\t"
        + leftHand.transform.position.x + "\t" + leftHand.transform.position.y + "\t" + leftHand.transform.position.z + "\t"
        + leftHand.transform.rotation.eulerAngles.x + "\t" + leftHand.transform.rotation.eulerAngles.y + "\t" + leftHand.transform.rotation.eulerAngles.z + "\t"
        + rightHand.transform.position.x + "\t" + rightHand.transform.position.y + "\t" + rightHand.transform.position.z + "\t"
        + rightHand.transform.rotation.eulerAngles.x + "\t" + rightHand.transform.rotation.eulerAngles.y + "\t" + rightHand.transform.rotation.eulerAngles.z + "\n");
      //}
      yield return new WaitForSeconds(.05f);
    }
  }

  IEnumerator RecordData2()
  {
    while (count2 > -1)
    {
      //Debug.Log(totalTime.ToString());
      //if (started)
      //{
      file2.WriteLine(totalTime.ToString() + "\t" + head.transform.position.x + "\t" + head.transform.position.y + "\t" + head.transform.position.z + "\t"
        + head.transform.rotation.eulerAngles.x + "\t" + head.transform.rotation.eulerAngles.y + "\t" + head.transform.rotation.eulerAngles.z + "\t"
        + leftHand.transform.position.x + "\t" + leftHand.transform.position.y + "\t" + leftHand.transform.position.z + "\t"
        + leftHand.transform.rotation.eulerAngles.x + "\t" + leftHand.transform.rotation.eulerAngles.y + "\t" + leftHand.transform.rotation.eulerAngles.z + "\t"
        + rightHand.transform.position.x + "\t" + rightHand.transform.position.y + "\t" + rightHand.transform.position.z + "\t"
        + rightHand.transform.rotation.eulerAngles.x + "\t" + rightHand.transform.rotation.eulerAngles.y + "\t" + rightHand.transform.rotation.eulerAngles.z + "\n");
      //}
      yield return new WaitForSeconds(.05f);
    }
  }
}
