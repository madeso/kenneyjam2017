using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
	Rigidbody2D rb;
	float pos;
	float y;

	public float Speed = 3;

	void Start () {
		this.rb = this.GetComponent<Rigidbody2D>();
		this.pos = this.rb.position.x;
		this.y = this.rb.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		float dx = 0;
		dx = Input.GetAxis("Horizontal");

		this.pos += dx * Time.deltaTime * this.Speed;
		this.rb.MovePosition(new Vector2(this.pos, this.y));
	}
}
