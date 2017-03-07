using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut_fruit : MonoBehaviour {

    private int idx;
    private int racount;
    private int gacount;
    private int bcount;

	// Use this for initialization
	void Start () {
        idx = 5;
        racount = 1;
        gacount = 1;
        bcount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        // RED APPLE
        if (other.collider.CompareTag("RedApple"))
        {
            Debug.Log("apple child count = " + other.collider.gameObject.transform.parent.childCount);

            if (other.collider.gameObject.transform.parent.childCount == 1 && racount < idx)
            {
                StartCoroutine(add_food(other.collider.gameObject.transform.parent.parent.GetChild(racount)));
                racount++;
            }

            other.collider.gameObject.transform.parent = null;
            other.collider.gameObject.AddComponent<Rigidbody>();

            StartCoroutine(delete_slice(other.collider.gameObject));
        }

        // GREEN APPLE
        if (other.collider.CompareTag("GreenApple"))
        {

            if (other.collider.gameObject.transform.parent.childCount == 1 && gacount < idx)
            {
                StartCoroutine(add_food(other.collider.gameObject.transform.parent.parent.GetChild(gacount)));
                gacount++;
            }

            other.collider.gameObject.transform.parent = null;
            other.collider.gameObject.AddComponent<Rigidbody>();

            StartCoroutine(delete_slice(other.collider.gameObject));
        }

        // BREAD
        if (other.collider.CompareTag("Bread"))
        {
            if (other.collider.gameObject.transform.parent.childCount > 1)
            {
                Debug.Log("hi");
                StartCoroutine(add_bread_tag(other.collider.gameObject.transform.parent.GetChild(1)));
            }


            if (other.collider.gameObject.transform.parent.childCount == 1 && bcount < idx)
            {
                StartCoroutine(add_food(other.collider.gameObject.transform.parent.parent.GetChild(bcount)));
                bcount++;
            }

            other.collider.gameObject.transform.parent = null;
            other.collider.gameObject.AddComponent<Rigidbody>();

            StartCoroutine(delete_slice(other.collider.gameObject));
        }
    }

    IEnumerator add_bread_tag(Transform go)
    {
        yield return new WaitForSeconds(1f);
        go.tag = "Bread";
    }

    IEnumerator delete_slice(GameObject other)
    {
        yield return new WaitForSeconds(2.5f);
        other.SetActive(false);
    }

    IEnumerator add_food(Transform A)
    {
        yield return new WaitForSeconds(5f);
        A.gameObject.SetActive(true);
    }
}
