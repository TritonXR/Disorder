using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pour_water : MonoBehaviour {

  ParticleSystem ps;

	// Use this for initialization
	void Start () {
    ps = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.rotation.z < -70 && this.gameObject.transform.rotation.z > -90)
    {
      ps.Play();
    } else
    {
      ps.Pause();
    }
	}
}
