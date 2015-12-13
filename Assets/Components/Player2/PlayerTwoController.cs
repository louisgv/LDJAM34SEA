﻿using UnityEngine;
using System.Collections;

public class PlayerTwoController : MonoBehaviour
{

	[Range(9.0f, 36.0f)]
	public float
		rotationSpeed = 9.0f;
	
	[Range(1.0f, 9.0f)]
	public float
		movementSpeed = 9.0f;

	// Update is called once per frame
	void Update ()
	{
		Vector3 input = new Vector3 (
			0, 
			Input.GetAxis ("P2Horizontal"), 
			0);
		transform.Rotate (input * rotationSpeed * Time.smoothDeltaTime);
		
		transform.position -= (
			transform.forward * Input.GetAxis ("P2Vertical") 
			* movementSpeed * Time.smoothDeltaTime);

//		transform.rotation = Quaternion.Euler (
//			transform.rotation.eulerAngles + 
//			input * Time.smoothDeltaTime * rotationSpeed);
//		
		
//		Quaternion target = Quaternion.Euler (transform.rotation.eulerAngles + input);
//		
//		transform.rotation = Quaternion.Slerp (
//			transform.rotation,
//			target,
//			 Time.deltaTime * rotationSpeed);		
		
		/*switch (myState) {
		case PlayerState.STUNNED:
			timer -= Time.deltaTime;

			if (timer < 0) {
				//timer
				myState = PlayerState.PLAYING;
				timer = 3.0f;
			}
			break;
		default:
			break;

		}*/
	}
}