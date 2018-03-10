using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove_coffee : MonoBehaviour {
  public GameObject headset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x > (.9*headset.transform.position.x) && this.transform.position.x < (1.1*headset.transform.position.x) &&
      this.transform.position.y > (.9*headset.transform.position.y) && this.transform.position.y < (1.1*headset.transform.position.y) &&
      this.transform.position.z > (.9*headset.transform.position.z) && this.transform.position.z < (1.1*headset.transform.position.z))
    {
      this.gameObject.transform.Find("coffee").gameObject.SetActive(false);
      Debug.Log("Update delete coffee");
    }
	}

  public void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.GetComponent<is_camera_head>() != null)
    {
      this.gameObject.transform.Find("coffee").gameObject.SetActive(false);
      Debug.Log("Trigger delete coffee");
    }
  }
}
