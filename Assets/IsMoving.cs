using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMoving : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

	bool isMoving()
	{
		// if the velocity of is zero, the ball is not moving, return false, else return true
		if (GetComponent<Rigidbody>().velocity == Vector3.zero)
		{
			return false;
		}
		else {
			return true;
		}
	}
}
