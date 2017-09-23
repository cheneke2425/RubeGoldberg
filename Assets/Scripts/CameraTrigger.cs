using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

	public Transform lookOverride; // set new lookat value
	public Transform moveOverride; // set new move value

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider activator)
	{
		CameraControll camControl = Camera.main.GetComponent<CameraControll>();

		//override the values in CamControll
		if (moveOverride != null)
		{
			
		}
		if (lookOverride != null)
		{
			
		}
	}

	//draw lines in the scene view
	void OnDrawGizmos()
	{
		if (moveOverride != null)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, moveOverride.position);}

		if (lookOverride != null)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(transform.position, lookOverride.position);}
	}
}
