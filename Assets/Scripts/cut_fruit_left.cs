using System.Collections;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class cut_fruit_left : MonoBehaviour
{

  public GameObject instruction;

  //public GameObject cut_right;
  //public GameObject cut_left;
  public GameObject breadslice;
  public GameObject knife;
  public Texture breadcrust_glow;
  public Texture carrot_glow;
  public Texture cucumber_glow;

  private int idx;
  private int bcount;
  private Vector3 initial_knife_pos;
  private Quaternion initial_knife_rot;

  private float breadHeight;
  private float breadTopY;
  private float breadBotY;

  private bool entered;

  //Timer
  private float startTime;
  private float stopTime;
  private float totalTime;
  private bool started = false;
  private bool finished = false;
  public int counter = 0;
  private int breadcounter = 0;
  public StreamWriter file_left;
  public StreamWriter file_right;
  private String filename_left;
  private String filename_right;

  Material glowmaterial;


  // Use this for initialization
  void Start()
  {
    idx = 6;
    bcount = 1;

    entered = false;

    filename_left = "LEFT_time_" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".txt";
    file_left = new StreamWriter(filename_left);

    breadHeight = breadslice.GetComponent<Renderer>().bounds.size.y;
    breadTopY = breadslice.transform.position.y + (breadHeight / 2);
    breadBotY = breadslice.transform.position.y - (breadHeight / 2);

    initial_knife_pos = knife.transform.position;
    initial_knife_rot = knife.transform.rotation;

    glowmaterial = new Material(Shader.Find("Particles/Additive (Soft)"));

    StartCoroutine(changeInstructions1());
  }

  IEnumerator changeInstructions1()
  {
    yield return new WaitForSeconds(5f);
    instruction.GetComponent<TextMesh>().text = "Cut up and down from \nLEFT to RIGHT…";
  }

  IEnumerator changeInstructions2()
  {
    instruction.GetComponent<TextMesh>().text = "Switch controller from \nLEFT hand to RIGHT hand...";
    yield return new WaitForSeconds(5f);
    instruction.GetComponent<TextMesh>().text = "Cut up and down from \nRIGHT to LEFT...";
  }

  private void OnTriggerEnter(Collider other)
  {
    // BREAD
    if (other.CompareTag("Bread"))
    {
      if (counter == 0)
      {
        startTime = Time.time;
        counter++;
      }
      if (counter == 38)
      {
        startTime = Time.time;
        counter++;
      }
      if (other.gameObject.transform.parent.childCount > 1)
      {
        if (other.gameObject.GetComponent<special_carrot>() != null)
        {
          StartCoroutine(add_bread_tag(other.gameObject.transform.parent.parent.GetChild(1)));
        }
        StartCoroutine(add_bread_tag(other.gameObject.transform.parent.GetChild(1)));
      }


      if (other.gameObject.transform.parent.childCount == 2 && bcount < idx)
      {
        StartCoroutine(delete_slice(other.gameObject.transform.parent.GetChild(1).gameObject));
        StartCoroutine(add_food(other.gameObject.transform.parent.parent.GetChild(bcount)));
        bcount++;
      }

      other.gameObject.transform.parent = null;
      other.gameObject.AddComponent<Rigidbody>();

      StartCoroutine(delete_slice(other.gameObject));
    }
  }

  IEnumerator add_bread_tag(Transform go)
  {
    yield return new WaitForSeconds(.5f);
    //yield return new WaitForSeconds(0.1f);
    go.tag = "Bread";
    go.GetComponent<Renderer>().material.shader = Shader.Find("FX/Flare");
    go.GetComponent<BoxCollider>().enabled = true;
  }

  IEnumerator delete_slice(GameObject other)
  {
    breadcounter++;
    Debug.Log(breadcounter);
    if (breadcounter == 37)
    {
      stopTime = Time.time;
      totalTime = stopTime - startTime;
      Debug.Log("totalTime = " + totalTime.ToString() + " stopTime = " + stopTime.ToString() + " startTime = " + startTime.ToString());
      file_left.WriteLine("Total Time in min:sec = " + Math.Floor(totalTime / 60) + ":" + Math.Round(totalTime % 60));
      file_left.Close();
      Debug.Log("FINISHED WITH LEFT!");

      //StartCoroutine(changeInstructions2());

      //knife.transform.SetPositionAndRotation(initial_knife_pos, initial_knife_rot);
    }
    Debug.Log(breadcounter);
    if (breadcounter == 75)
    {
      stopTime = Time.time;
      totalTime = stopTime - startTime;
      Debug.Log("totalTime = " + totalTime.ToString() + " stopTime = " + stopTime.ToString() + " startTime = " + startTime.ToString());
      file_right.WriteLine("Total Time in min:sec = " + Math.Floor(totalTime / 60) + ":" + Math.Round(totalTime % 60));
      file_right.Close();

      //cut_left.SetActive(false);
      StartCoroutine(back_to_main_menu());
    }
    yield return new WaitForSeconds(0.5f);
    //yield return new WaitForSeconds(0.2f);
    other.SetActive(false);
  }

  IEnumerator back_to_main_menu()
  {
    yield return new WaitForSeconds(5f);
    SceneManager.LoadScene(0);
  }

  IEnumerator add_food(Transform A)
  {
    yield return new WaitForSeconds(2f);
    //yield return new WaitForSeconds(1f);
    A.gameObject.SetActive(true);
  }

  IEnumerator change_sign(GameObject sign_left, GameObject sign_right)
  {
    yield return new WaitForSeconds(3f);
    //yield return new WaitForSeconds(1f);
    sign_right.SetActive(false);
    sign_left.SetActive(true);
  }
}
