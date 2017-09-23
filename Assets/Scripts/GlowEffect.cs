using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<MeshRenderer>().enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isMoving())
		{
			if (GetComponent<MeshRenderer>().enabled == false)
			{
				GetComponent<MeshRenderer>().enabled = true;
			}
		}
		else {
			if (GetComponent<MeshRenderer>().enabled == true)
			{
				GetComponent<MeshRenderer>().enabled = false;
			}
		}
		
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("collided");
		//when ball collides with object, object renderer is enabled

		if (isMoving())
		{
			if(!collision.gameObject.GetComponent<MeshRenderer>().enabled)
			{
				collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
		}

	}

	void OnCollisionExit(Collision collision)
	{
		Debug.Log("collision ended");
		// when collision ends, renderer is disabled
		if (isMoving())
		{
			if (collision.gameObject.GetComponent<MeshRenderer>().enabled)
			{
				collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
		}

	}

	bool isMoving()
	{
		if (GetComponent<Rigidbody>().velocity == Vector3.zero)
		{
			return false;
		}
		else {
			return true;
		}
	}

}
