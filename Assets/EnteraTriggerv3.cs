using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteraTriggerv3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider activator)
	{
		Debug.Log("Enter Trigger");
		StartCoroutine(sinceEnterTrigger(1f));

	}

	IEnumerator sinceEnterTrigger(float sec)
	{
		yield return new WaitForSeconds(sec);
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
	}
}
