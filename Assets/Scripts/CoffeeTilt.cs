using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTilt : MonoBehaviour
{

    public Vector3 start = new Vector3(0.0f, 1.0f, 0.0f);
    public Vector3 end = new Vector3(0.0f, 0.0f, 0.0f);
    public float y;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If tilted, then pour portion of liquid out based on percentage.

        //Must fix localPosition and Vectors. It's currently the mug affected. Need to change to the coffee within the mug (aka child)

        float xAngle = transform.rotation.eulerAngles.x;
        float zAngle = transform.rotation.eulerAngles.z;

        //All transforms for miniscus. All angles from mug.
        if (xAngle >= 30)
        {
            float xAngleScaled = Mathf.Abs(xAngle * 100 / 180);
            //float fullScale = 
            transform.localPosition = new Vector3(0, y * (100 - xAngleScaled / 100), 0);
        }

        if (zAngle >= 30)
        {
            float zAngleScaled = Mathf.Abs(zAngle * 100 / 180);
            transform.localPosition = new Vector3(0, y * (100 - zAngleScaled / 100), 0);
        }

        if (xAngle <= -30)
        {
            float xAngleScaled = Mathf.Abs(xAngle * 100 / 180);
            transform.localPosition = new Vector3(0, y * (100 - xAngleScaled / 100), 0);
        }

        if (zAngle <= -30)
        {
            float zAngleScaled = Mathf.Abs(zAngle * 100 / 180);
            transform.localPosition = new Vector3(0, y * (100 - zAngleScaled / 100), 0);
        }
    }
}