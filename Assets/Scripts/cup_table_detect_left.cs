using System.Collections;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class cup_table_detect_left : MonoBehaviour
{

  public GameObject instruction;

  public GameObject mugLeft1;
  public GameObject mugLeft2;
  public GameObject mugLeft3;
  public GameObject mugLeft4;
  public GameObject mugLeft5;
  public GameObject mugRight1;
  public GameObject mugRight2;
  public GameObject mugRight3;
  public GameObject mugRight4;
  public GameObject mugRight5;

  public GameObject leftController;
  public GameObject rightController;
  private Vector3 initial_rightController_pos;
  private Quaternion initial_rightController_rot;
  private Vector3 initial_leftController_pos;
  private Quaternion initial_leftController_rot;

  private int idx;
  private int bcount;

  private float mugHeight;
  private float mugTopY;
  private float mugBotY;

  private bool entered;

  //Timer
  private float startTime;
  private float stopTime;
  private float totalTime;
  private bool started = false;
  private bool finished = false;
  public int counter = 0;
  private int breadcounter = 0;
  private int roundCounter;
  public StreamWriter file_left;
  public StreamWriter file_right;
  private String filename_left;
  private String filename_right;

  // Use this for initialization
  void Start()
  {
    idx = 6;
    bcount = 1;

    entered = false;

    mugHeight = mugLeft1.GetComponent<Renderer>().bounds.size.y;
    mugTopY = mugLeft1.transform.position.y + (mugHeight / 2);
    mugBotY = mugLeft1.transform.position.y - (mugHeight / 2);

    //Usable
    initial_leftController_pos = leftController.transform.position;
    initial_leftController_rot = leftController.transform.rotation;
    initial_rightController_pos = rightController.transform.position;
    initial_rightController_rot = rightController.transform.rotation;

    //Usable
    StartCoroutine(changeInstructions1());
  }

    //Usable
  IEnumerator changeInstructions1()
  {
    yield return new WaitForSeconds(5f);
    instruction.GetComponent<TextMesh>().text = "Move the mug along the arc \nfrom LEFT to RIGHT…";
    yield return new WaitForSeconds(10f);
    instruction.gameObject.SetActive(false);
  }

  //Usable
  IEnumerator changeInstructions2()
  {
    yield return new WaitForSeconds(5f);
    instruction.GetComponent<TextMesh>().text = "Switch controller from \nLEFT hand to RIGHT hand...";
    instruction.gameObject.SetActive(true);
    yield return new WaitForSeconds(5f);
    instruction.GetComponent<TextMesh>().text = "Move the mug along the arc \nfrom RIGHT to LEFT...";
    yield return new WaitForSeconds(5f);
    instruction.gameObject.SetActive(false);
  }

    //Usable
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Mug"))
    {
      counter++;
      other.gameObject.transform.parent = null;
      other.gameObject.AddComponent<Rigidbody>();
    }
    if(counter == 5)
    {
      changeInstructions2();
      mugLeft1.SetActive(false);
      mugLeft2.SetActive(false);
      mugLeft3.SetActive(false);
      mugLeft4.SetActive(false);
      mugLeft5.SetActive(false);
      mugRight1.SetActive(true);
      mugRight2.SetActive(true);
      mugRight3.SetActive(true);
      mugRight4.SetActive(true);
      mugRight5.SetActive(true);
    }
  }

    //Usable
  IEnumerator back_to_main_menu()
  {
    yield return new WaitForSeconds(5f);
    SceneManager.LoadScene(2);
  }

  IEnumerator add_otherMugs(Transform A)
  {
    yield return new WaitForSeconds(2f);
    A.gameObject.SetActive(true);
  }
}