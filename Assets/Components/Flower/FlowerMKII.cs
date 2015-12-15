﻿using UnityEngine;
using System.Collections;

public class FlowerMKII : Flower
{


	private FlowerSound flowerSounds;

	public void Awake ()
	{
		flowerSounds = GetComponent<FlowerSound> ();	
	}

	[Range (0.1f, 1f)]
	public float
		prefabGrowthSpeed = 0.1f;

	void Start ()
	{
		transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Grow the block
		if (state.Equals (FlowerState.IS_GROWING)) {
			Grow ();
			flowerSounds.blossom ();
		}


		if (state.Equals (FlowerState.CHOPPED)) {





			// Disable Trigger
			// Apply a force up
			// Switch State to Draggable

		}
	}

	new void Grow ()
	{
		base.Grow ();
		transform.localScale += Vector3.one * Time.smoothDeltaTime * prefabGrowthSpeed;
	}
}
