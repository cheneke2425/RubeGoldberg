﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

	// two targets that camera can detect
	public Transform firstTarget;
	public Transform secondTarget;
	public Transform thirdTarget;

	public float dampTime = 0.2f;

	private Vector3 targetPos; // the actual position that camera should look at
	private Vector3 moveToTarget; // where is the camera supposed to go?
	private Vector3 moveVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Vector3 firstTarPos = Vector3.zero;
		//Vector3 secondTarPos = Vector3.zero;
		//Vector3 thirdTarPos = Vector3.zero;

		if (firstTarget != null && secondTarget != null && thirdTarget != null)
		{
			//findTargetPos(firstTarget, firstTarPos);
			//findTargetPos(secondTarget, secondTarPos);
			//findTargetPos(thirdTarget, thirdTarPos);

			// if first target is moving and second is not, camera will only look at first target, no zooming
			if (isMoving(firstTarget) && !isMoving(secondTarget) && !isMoving(thirdTarget))
			{
				targetPos = firstTarget.transform.position;
				moveToTarget = new Vector3(targetPos.x - 10, targetPos.y, targetPos.z);
			}
			// if first target is not moving and the second is, camera will only look at second target, no zooming
			else if (!isMoving(firstTarget) && isMoving(secondTarget) && !isMoving(thirdTarget))
			{
				targetPos = secondTarget.transform.position;
				moveToTarget = new Vector3(targetPos.x - 10, targetPos.y, targetPos.z);
			}
			// if first target is not moving and the second is, camera will only look at second target, no zooming
			else if (!isMoving(firstTarget) && !isMoving(secondTarget) && isMoving(thirdTarget))
			{
				targetPos = thirdTarget.transform.position;
				moveToTarget = new Vector3(targetPos.x - 10, targetPos.y, targetPos.z);
			}
			//if first and second target are both moving, camera will look at the midpoint of the two targets, zooms depend on distance
			else
			{
				targetPos = (firstTarget.position + secondTarget.position + thirdTarget.position) / 3; 
				float zoom = 10 + Mathf.Abs(firstTarget.transform.position.z - secondTarget.transform.position.z) * 3 / 4;
				moveToTarget = new Vector3(targetPos.x - zoom, targetPos.y, targetPos.z);
			}

		   transform.position = Vector3.SmoothDamp(transform.position, moveToTarget, ref moveVelocity, dampTime);
		}
	}

	// check if target is moving, if so return true
	bool isMoving(Transform target)
	{
		if (target.GetComponent<Rigidbody>().velocity != Vector3.zero)
		{
			return true;
		}
		else {
			return false;
		}
	}

	/*void findTargetPos(Transform target, Vector3 findPos)
	{
		if (isMoving(target))
		{
			findPos = target.position;
		}
		else {
			findPos = Vector3.zero;
		}
	}*/
}
