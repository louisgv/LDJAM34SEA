﻿using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
	[Range(1f,18f)]
	public float
		GROW_MAX = 9f;

	public float growthProgress = 0;
	
	public float growthForBridge = 4.5f;
	
	[Range(1, 10)]
	public float
		growthSpeed = 1f;
	
	private Rigidbody rigidBody;
	
	public enum FlowerState
	{
		IS_GROWING,
		CHOPPED,
		CHOPPED_DEAD,
		FULL_GROWN
	}
	
	public FlowerState state = FlowerState.IS_GROWING;
		
	void Awake ()
	{
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	public void BeChopped ()
	{
		if (growthProgress < growthForBridge) {
			Destroy (this.gameObject);
			return;
		}
		
		rigidBody.isKinematic = false;
		
		rigidBody.AddForce (Vector3.up * 900f);
		
	}
	
	void BeFullGrown ()
	{
		state = FlowerState.FULL_GROWN;
		// TODO: Game OVER, P1 Win. 
		// ANIMATION with Flower full bloom. UNCOMMENT THIS FOR WINNER SCENE
		
//		GameManager.state = GameManager.GameState.GAMEOVER_W2;
	}
	
	public void BeChoppedDead ()
	{
		state = FlowerState.CHOPPED_DEAD;
		// TODO: Call the building bridge method, could be a static method.
		if (growthProgress > growthForBridge) {
//			centralBridge.BuildBridge ();
		}
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (state.Equals (FlowerState.IS_GROWING)) {
			Grow ();
		}
		if (transform.position.y < 100.0f) {
			Destroy (this.gameObject);
		}
	}
	
	protected void Grow ()
	{
		if (growthProgress > GROW_MAX) {			
			BeFullGrown ();
			return;
		}
		growthProgress += Time.deltaTime * growthSpeed;
	}
}
