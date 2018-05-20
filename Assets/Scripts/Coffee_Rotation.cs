using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Coffee_Rotation : MonoBehaviour {

    public GameObject coffee_1;
    public GameObject coffee_2;
    public GameObject coffee_3;
    public GameObject coffee_4;
    public GameObject coffee_5;
    public GameObject coffee_6;
    public GameObject coffee_7;
    public GameObject coffee_8;
    public GameObject coffee_9;
    public GameObject coffee_10;
    public GameObject mug;
    public GameObject Controller_Left;
    public GameObject Controller_Right;
    public GameObject attach_Left;
    public GameObject attach_Right;
    public object coffee;
    public bool grabbing;
    public float currentAngleX_Left;
    public float currentAngleZ_Left;
    public float currentAngleX_Right;
    public float currentAngleZ_Right;
    public StreamWriter file;
    public StreamWriter file_left;
    public string filename_left;
    public StreamWriter file_right;
    public string filename_right;

    public List<float> angleList;
    public float lowestValue;

    private float startTime;
    private float totalTime;

    // Use this for initialization
    void Start () {

        grabbing = false;

        if(Controller_Left)
        {
            filename_left = "LEFT_Rotation_time_" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".txt";
            Debug.Log("Left");
            file = new StreamWriter(filename_left);
            file.WriteLine("Time\tleft_x\tleft_y\tleft_z\tz_cup_rotations\n");
            startTime = Time.time;
            StartCoroutine(RecordData());
        }
        else if(Controller_Right)
        {
            filename_right = "RIGHT_Rotation_time_" + System.DateTime.Now.ToString("MM-dd-yy_hh-mm-ss") + ".txt";
            Debug.Log("Right");
            file = new StreamWriter(filename_right);
            file.WriteLine("Time\tright_x\tright_y\tright_z\tz_cup_rotations\n");
            startTime = Time.time;
            StartCoroutine(RecordData());
        }
    }

    // Update is called once per frame
    void Update () {

        Debug.Log("z = " + Controller_Right.transform.rotation.z * 180);

        currentAngleZ_Left = Mathf.Abs(Controller_Left.transform.rotation.z * 180);
        currentAngleZ_Right = Mathf.Abs(Controller_Right.transform.rotation.z * 180);

        if (mug.transform.parent == attach_Right.transform || mug.transform.parent == attach_Left.transform)
        {
            grabbing = true;

            if (currentAngleZ_Left >= 90)
            {
                coffee_10.SetActive(false);
            }
            if (currentAngleZ_Right >= 90)
            {
                coffee_10.SetActive(false);
            }

            if (currentAngleZ_Left >= 82.8)
            {
                coffee_9.SetActive(false);
            }
            if (currentAngleZ_Right >= 82.8)
            {
                coffee_9.SetActive(false);
            }

            
            if (currentAngleZ_Left >= 75.6)
            {
                coffee_8.SetActive(false);
            }
            if (currentAngleZ_Right >= 75.6)
            {
                coffee_8.SetActive(false);
            }

            if (currentAngleZ_Left >= 68.4)
            {
                coffee_7.SetActive(false);
            }
            if (currentAngleZ_Right >= 68.4)
            {
                coffee_7.SetActive(false);
            }

            if (currentAngleZ_Left >= 61.2)
            {
                coffee_6.SetActive(false);
            }
            if (currentAngleZ_Right >= 61.2)
            {
                coffee_6.SetActive(false);
            }

            if (currentAngleZ_Left >= 54)
            {
                coffee_5.SetActive(false);
            }
            if (currentAngleZ_Right >= 54)
            {
                coffee_5.SetActive(false);
            }

            if (currentAngleZ_Left >= 46.8)
            {
                coffee_4.SetActive(false);
            }
            if (currentAngleZ_Right >= 46.8)
            {
                coffee_4.SetActive(false);
            }

            if (currentAngleZ_Left >= 39.6)
            {
                coffee_3.SetActive(false);
            }
            if (currentAngleZ_Right >= 39.6)
            {
                coffee_3.SetActive(false);
            }

            if (currentAngleZ_Left >= 32.4)
            {
                coffee_2.SetActive(false);
            }
            if (currentAngleZ_Right >= 32.4)
            {
                coffee_2.SetActive(false);
            }

            if (currentAngleZ_Left >= 25.2)
            {
                coffee_1.SetActive(false);
            }
            if (currentAngleZ_Right >= 25.2)
            {
                coffee_1.SetActive(false);
            }

            totalTime = Time.time - startTime;
            //Debug.Log(totalTime);
        }
        else
        {
            grabbing = false;
        }

        StartCoroutine(RecordData());
    }
    IEnumerator RecordData()
    {
        while (grabbing)
        {
            if (Controller_Left)
            {
                file.WriteLine(totalTime.ToString() + "\t" +
                    + Controller_Left.transform.position.x + "\t" + Controller_Left.transform.position.y + "\t" + Controller_Left.transform.position.z + "\t"
                    + currentAngleZ_Left +"\n");

                Debug.Log(startTime + ", " + totalTime + ", " + Controller_Left.transform.position.x + ", " + Controller_Left.transform.position.y + ", " + Controller_Left.transform.position.z);

                yield return new WaitForSeconds(.1f);
            }
            else if (Controller_Right)
            {
                file.WriteLine(totalTime.ToString() + "\t" +
                    + Controller_Right.transform.position.x + "\t" + Controller_Right.transform.position.y + "\t" + Controller_Right.transform.position.z + "\t"
                    + currentAngleZ_Right +"\n");
               
                yield return new WaitForSeconds(.1f);
            }
            /*
            file.WriteLine(totalTime.ToString() + "\t" +
                +Controller_Left.transform.position.x + "\t" + Controller_Left.transform.position.y + "\t" + Controller_Left.transform.position.z + "\t"
                + Controller_Left.transform.rotation.eulerAngles.x + "\t" + Controller_Left.transform.rotation.eulerAngles.y + "\t" + Controller_Left.transform.rotation.eulerAngles.z + "\t"
                + Controller_Right.transform.position.x + "\t" + Controller_Right.transform.position.y + "\t" + Controller_Right.transform.position.z + "\t"
                + Controller_Right.transform.rotation.eulerAngles.x + "\t" + Controller_Right.transform.rotation.eulerAngles.y + "\t" + Controller_Right.transform.rotation.eulerAngles.z + "\n");
            //}
            yield return new WaitForSeconds(.1f);*/
        }
    }
}