using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//when space is pressed, disable joint so that the ball can fall
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<SpringJoint>().breakForce = 0f;
		}

	}
}
