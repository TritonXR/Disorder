using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee_Rotation : MonoBehaviour {

    public GameObject coffee_1;
    public GameObject coffee_2;
    public GameObject coffee_3;
    public GameObject coffee_4;
    public GameObject coffee_5;
    public GameObject coffee_6;
    public GameObject coffee_7;
    public GameObject coffee_8;
    public GameObject mug;
    public GameObject Controller_Left;
    public GameObject Controller_Right;
    public bool grabbing;
    public float currentAngleX_Left;
    public float currentAngleZ_Left;
    public float lowestAngleX_Left;
    public float lowestAngleZ_Left;
    public float highestAngleX_Left;
    public float highestAngleZ_Left;
    public float currentAngleX_Right;
    public float currentAngleZ_Right;
    public float lowestAngleX_Right;
    public float lowestAngleZ_Right;
    public float highestAngleX_Right;
    public float highestAngleZ_Right;
    public float lowestLevelX_Left;
    public float lowestLevelZ_Left;
    public float highestLevelX_Left;
    public float highestLevelZ_Left;
    public float lowestLevelX_Right;
    public float lowestLevelZ_Right;
    public float highestLevelX_Right;
    public float highestLevelZ_Right;
    public List<float> angleList;
    public float lowestValue;

    // Use this for initialization
    void Start () {

        highestAngleX_Left = 360;
        highestAngleZ_Left = 360;
        highestAngleX_Right = 360;
        highestAngleZ_Right = 360;

        //coffee.transform.rotation.Set(0, 0, 0, 1);
        grabbing = false;
        angleList.Add(lowestLevelX_Left);
        angleList.Add(lowestLevelZ_Left);
        angleList.Add(highestLevelX_Left);
        angleList.Add(highestLevelZ_Left);
        angleList.Add(lowestLevelX_Right);
        angleList.Add(lowestLevelZ_Right);
        angleList.Add(highestLevelX_Right);
        angleList.Add(highestLevelZ_Right);
        lowestValue = 180;
    }

    private void OnTriggerEnter(Collider other)
    {
        grabbing = true;
    }

    void OnTriggerExit(Collider other)
    {
        grabbing = false;
    }

    // Update is called once per frame
    void Update () {

        //coffee.transform.rotation.Set(0, 0, 0, 1);
        currentAngleX_Left = Controller_Left.transform.rotation.eulerAngles.x;
        currentAngleZ_Left = Controller_Left.transform.rotation.eulerAngles.x;
        currentAngleX_Right = Controller_Right.transform.rotation.eulerAngles.x;
        currentAngleZ_Right = Controller_Right.transform.rotation.eulerAngles.x;

        if(grabbing)
        {
            //Rotation for height
            Debug.Log(Controller_Left.transform.rotation.x * 180);
            Debug.Log(Controller_Left.transform.rotation.z * 180);
            Debug.Log(Controller_Right.transform.rotation.x * 180);
            Debug.Log(Controller_Right.transform.rotation.z * 180);

        }

        if (currentAngleX_Left < highestAngleX_Left && currentAngleX_Left > 180)
        {
            highestAngleX_Left = Controller_Left.transform.rotation.eulerAngles.x;
        }
        if (currentAngleX_Left > lowestAngleX_Left && currentAngleX_Left < 180)
        {
            lowestAngleX_Left = Controller_Left.transform.rotation.eulerAngles.x;
        }
        if (currentAngleZ_Left < highestAngleZ_Left && currentAngleZ_Left > 180)
        {
            highestAngleZ_Left = Controller_Left.transform.rotation.eulerAngles.x;
        }
        if (currentAngleZ_Left > lowestAngleZ_Left && currentAngleX_Left < 180)
        {
            lowestAngleZ_Left = Controller_Right.transform.rotation.eulerAngles.x;
        }
        if (currentAngleX_Right < highestAngleX_Right && currentAngleX_Left > 180)
        {
            highestAngleX_Right = Controller_Right.transform.rotation.eulerAngles.x;
        }
        if (currentAngleX_Right > lowestAngleX_Right && currentAngleX_Left < 180)
        {
            lowestAngleX_Right = Controller_Right.transform.rotation.eulerAngles.x;
        }
        if (currentAngleZ_Right < highestAngleZ_Right && currentAngleX_Left > 180)
        {
            highestAngleZ_Right = Controller_Right.transform.rotation.eulerAngles.x;
        }
        if (currentAngleZ_Right > lowestAngleZ_Right && currentAngleX_Left < 180)
        {
            lowestAngleZ_Right = Controller_Right.transform.rotation.eulerAngles.x;
        }

        lowestLevelX_Left = Mathf.Abs(lowestAngleX_Left - 180);
        lowestLevelZ_Left = Mathf.Abs(lowestAngleZ_Left - 180);
        highestLevelX_Left = Mathf.Abs(highestAngleX_Left - 180);
        highestLevelZ_Left = Mathf.Abs(highestAngleZ_Left - 180);
        lowestLevelX_Right = Mathf.Abs(lowestAngleX_Right - 180);
        lowestLevelZ_Right = Mathf.Abs(lowestAngleZ_Right - 180);
        highestLevelX_Right = Mathf.Abs(highestAngleX_Right - 180);
        highestLevelZ_Right = Mathf.Abs(highestAngleZ_Right - 180);

        if (lowestValue > lowestLevelX_Left)
        {
            lowestValue = lowestLevelX_Left;
        }
        if (lowestValue > lowestLevelZ_Left)
        {
            lowestValue = lowestLevelZ_Left;
        }
        if (lowestValue > highestLevelX_Left)
        {
            lowestValue = highestLevelX_Left;
        }
        if (lowestValue > highestLevelZ_Left)
        {
            lowestValue = highestLevelZ_Left;
        }
        if (lowestValue > lowestLevelX_Right)
        {
            lowestValue = lowestLevelX_Right;
        }
        if (lowestValue > lowestLevelZ_Right)
        {
            lowestValue = lowestLevelZ_Right;
        }
        if (lowestValue > highestLevelX_Right)
        {
            lowestValue = highestLevelX_Right;
        }
        if (lowestValue > highestLevelZ_Right)
        {
            lowestValue = highestLevelZ_Right;
        }
    //    coffee.transform.localScale = new Vector3(1, lowestValue/180, 1);

        if (grabbing)
        {
            if (Controller_Left.transform.rotation.eulerAngles.x <= 270 && Controller_Left.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_1.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.x <= 270 && Controller_Right.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_1.SetActive(false);
            }
            if (Controller_Left.transform.rotation.eulerAngles.z <= 270 && Controller_Left.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_1.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.z <= 270 && Controller_Right.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_1.SetActive(false);
            }

            if (Controller_Left.transform.rotation.eulerAngles.x <= 270 && Controller_Left.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_2.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.x <= 270 && Controller_Right.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_2.SetActive(false);
            }
            if (Controller_Left.transform.rotation.eulerAngles.z <= 270 && Controller_Left.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_2.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.z <= 270 && Controller_Right.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_2.SetActive(false);
            }

            if (Controller_Left.transform.rotation.eulerAngles.x <= 270 && Controller_Left.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_3.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.x <= 270 && Controller_Right.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_3.SetActive(false);
            }
            if (Controller_Left.transform.rotation.eulerAngles.z <= 270 && Controller_Left.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_3.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.z <= 270 && Controller_Right.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_3.SetActive(false);
            }

            if (Controller_Left.transform.rotation.eulerAngles.x <= 270 && Controller_Left.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_4.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.x <= 270 && Controller_Right.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_4.SetActive(false);
            }
            if (Controller_Left.transform.rotation.eulerAngles.z <= 270 && Controller_Left.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_4.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.z <= 270 && Controller_Right.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_4.SetActive(false);
            }

            if (Controller_Left.transform.rotation.eulerAngles.x <= 270 && Controller_Left.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_5.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.x <= 270 && Controller_Right.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_5.SetActive(false);
            }
            if (Controller_Left.transform.rotation.eulerAngles.z <= 270 && Controller_Left.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_5.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.z <= 270 && Controller_Right.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_5.SetActive(false);
            }

            if (Controller_Left.transform.rotation.eulerAngles.x <= 270 && Controller_Left.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_6.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.x <= 270 && Controller_Right.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_6.SetActive(false);
            }
            if (Controller_Left.transform.rotation.eulerAngles.z <= 270 && Controller_Left.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_6.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.z <= 270 && Controller_Right.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_6.SetActive(false);
            }

            if (Controller_Left.transform.rotation.eulerAngles.x <= 270 && Controller_Left.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_7.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.x <= 270 && Controller_Right.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_7.SetActive(false);
            }
            if (Controller_Left.transform.rotation.eulerAngles.z <= 270 && Controller_Left.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_7.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.z <= 270 && Controller_Right.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_7.SetActive(false);
            }

            if (Controller_Left.transform.rotation.eulerAngles.x <= 270 && Controller_Left.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_8.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.x <= 270 && Controller_Right.transform.rotation.eulerAngles.x >= 90)
            {
                coffee_8.SetActive(false);
            }
            if (Controller_Left.transform.rotation.eulerAngles.z <= 270 && Controller_Left.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_8.SetActive(false);
            }
            if (Controller_Right.transform.rotation.eulerAngles.z <= 270 && Controller_Right.transform.rotation.eulerAngles.z >= 90)
            {
                coffee_8.SetActive(false);
            }
        }
    }
}

//X and Z axis passes at >90 or <-90.