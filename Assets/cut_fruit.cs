using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut_fruit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Apple"))
        {
            other.collider.gameObject.transform.parent = null;
            other.collider.gameObject.AddComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Knife"))
        {
            Debug.Log("Trigger Exit");
            this.gameObject.transform.parent = null;
            this.gameObject.AddComponent<Rigidbody>();
        }
    }

}
