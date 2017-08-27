﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public float TargetVelocity = 300;

	Rigidbody2D b;

	// Use this for initialization
	void Start () {
		this.b = this.GetComponent<Rigidbody2D>();
	}

	int times = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
		// stop from bouncing horizontally
		if( Mathf.Abs(b.velocity.y) < 0.1f )
		{
			this.times += 1;
		}
		else {
			this.times = 0;
		}

		if( times > 3 ) {
			print("Adjusting..");
			this.b.velocity = new Vector2(b.velocity.x, b.velocity.y * 3);
		}

		// keep velocity around target
		var v = this.b.velocity.magnitude;
		var newv = v + (this.TargetVelocity - v) * 0.1f;
		this.b.velocity = this.b.velocity.normalized * newv;
	}
}
