using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
	public Rigidbody2D BallToSpawn;

	void Start () {
		
	}
	
	void Update () {
		if( Input.GetKeyDown(KeyCode.LeftControl) ) 
		{
			var ball = GameObject.Instantiate(BallToSpawn);
			ball.transform.position = this.transform.position + new Vector3(0, 0.5f, 0);
			ball.AddForce(new Vector2(0, 300));
		}
	}
}
