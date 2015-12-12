﻿using UnityEngine;
using System.Collections;

public class PlayerTwoRotation : MonoBehaviour {

	[Range(1.0f, 9.0f)]
	public float rotationSpeed = 9.0f;

	public float timer = 3.0f;

	public enum PlayerState{
		PLAYING,
		STUNNED,
		DEAD
	}

	//reffering to our enum PlayState value Playing
	//type of myState is PlayerState.playing
	public PlayerState myState = PlayerState.PLAYING;

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter (Collider collider){
		if (collider.gameObject.tag ==  "Seed") {
			//here goes the co-routine
			StartCoroutine(BeStunned());
		}
	}

	IEnumerator BeStunned(){
		myState = PlayerState.STUNNED;

		yield return new WaitForSeconds (3.0f);

		myState = PlayerState.PLAYING;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (
			-Input.GetAxis ("Rotation.Vertical"),
			Input.GetAxis ("Rotation.Horizontal"),
			0));

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
