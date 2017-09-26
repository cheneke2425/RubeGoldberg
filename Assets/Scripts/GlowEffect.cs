using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//everything starts with meshrenderer disabled
		GetComponent<MeshRenderer>().enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		// the ball's meshrenderer is enabled as soon as the ball starts moving, disabled when the ball stops
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

	// if a moving ball is touching an object, the object's mesh renderer is enabled
	void OnCollisionStay(Collision collision)
	{
		// only if the ball is moving, the object then can glow
		if (isMoving())
		{
			collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
		}
		else {
			collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
		}

	}

	void OnCollisionExit(Collision collision)
	{
		StartCoroutine(sinceCollisionEnded(2.5f, collision));
	}

	// check if the ball is moving
	bool isMoving()
	{
		// if the velocity of the ball is zero, the ball is not moving, return false, else return true
		if (GetComponent<Rigidbody>().velocity == Vector3.zero)
		{
			return false;
		}
		else {
			return true;
		}
	}

	// wait for seconds after collision ended and then disables meshrenderer
	IEnumerator sinceCollisionEnded(float sec, Collision collisionInfo)
	{
		yield return new WaitForSeconds(sec);

		collisionInfo.gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
}
