using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour {

	public GameObject Elevator;
	public float dampTime = 6f;

	public Vector3 target;

	private Vector3 moveVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Transform elevator = Elevator.transform;

		if (GetComponent<Rigidbody>().isKinematic)
		{
			Elevator.transform.position = Vector3.SmoothDamp(Elevator.transform.position, target, ref moveVelocity, dampTime);
			Elevator.GetComponent<MeshRenderer>().enabled = true;

			CameraControll camControll = Camera.main.GetComponent<CameraControll>();

			camControll.secondTarget = elevator;
		}
		
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
