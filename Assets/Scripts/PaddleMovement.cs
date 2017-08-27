using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
	Rigidbody2D rb;
	float pos;
	float y;
	float starty;

	float jump = 0;
	float jumptimer = 0;

	public float Speed = 3;
	public float JumpPower = 10;
	public float JumpGravivty = 100;
	public float JumpTime = 0.1f;

	void Start () {
		this.rb = this.GetComponent<Rigidbody2D>();
		this.pos = this.rb.position.x;
		this.starty = this.y = this.rb.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		float dx = 0;
		dx = Input.GetAxis("Horizontal");

		// var onground = y < starty + 0.0001f;
		// if(onground
		if(Input.GetButton("Jump") ) {
			if( this.jumptimer < JumpTime )
			{
				jump = this.JumpPower;
				this.jumptimer += Time.deltaTime;
			}
		}
		else {
			jumptimer = 0;
		}

		jump -= this.JumpGravivty * Time.deltaTime;
		y += jump * Time.deltaTime;
		if(y < starty ) {
			y = starty;
			jump = 0;
		}

		this.pos += dx * Time.deltaTime * this.Speed;
		this.rb.MovePosition(new Vector2(this.pos, this.y));
	}
}
