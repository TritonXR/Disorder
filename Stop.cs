using UnityEngine;
using System.Collections;

public class Stop : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		GameObject.Find("").SendMessage("Finish");
	}
}