using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

	public Transform lookAtTarget; // what is the camera supposed to look at?
	public Transform moveToTarget; // where is th camera supposed to go?

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// is "lookAtTarget" defind? if so, it won;t be "null"
		if (lookAtTarget != null)
		{
			//make this transform look at thing
			transform.LookAt(lookAtTarget.position);
		}

		// is "moveTarget" defined, and does it still exist? if so, it won't be null
		if (moveToTarget != null)
		{
			//make sure the camera follows the ball from a certain distance
			//moveToTarget.position = new Vector3(lookAtTarget.position.x, lookAtTarget.position.y, lookAtTarget.position.z + 5f);

			//make this transform move towards this thing

			//first, calculate the vector from camera (point A) to destination (point B)

			Vector3 moveDirection = moveToTarget.position - transform.position;

			// is the moveDirection rection greater than a? if so, normalize it (change the magnitude to 1)
			if (moveDirection.magnitude > 1)
			{
				moveDirection = moveDirection.normalized;
				// moveDirection = Vector3.Normalize (movedirection);

			}

			//move this transform towards its destination

			transform.position += moveDirection * Time.deltaTime * 10f;
		}
		
	}
}
