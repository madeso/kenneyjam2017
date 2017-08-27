using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public float TargetVelocity = 300;
	public float TargetAdoption = 0.1f;
	public float MaxVelocity = 200;

	public AudioClip SoundBlocker;
	public AudioClip SoundTile;
	public AudioClip SoundPaddle;

	Rigidbody2D b;

	SpriteRenderer spr;
	float color = 1;

	// Use this for initialization
	void Start () {
		this.spr = this.GetComponent<SpriteRenderer>();
		this.b = this.GetComponent<Rigidbody2D>();
	}

	int times = 0;

	float Inter(float st, float v, float en)
	{
		return st + v*(en-st);
	}

	void Update() {
		color = Mathf.Min(color+Time.deltaTime*3, 1.0f);
		float c = Inter(1.0f, color, 0.4f);
		this.spr.color = new Color(c,c,c);
	}
	
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
			this.b.velocity = new Vector2(b.velocity.x, b.velocity.y + Random.Range(-3, 3));
		}

		// keep velocity around target
		var v = this.b.velocity.magnitude;
		var newv = Mathf.Min(this.MaxVelocity, v + (this.TargetVelocity - v) * this.TargetAdoption);
		this.b.velocity = this.b.velocity.normalized * newv;
	}

	void Flash() {
		color = 0.0f;
	}

	void ShakeTiles() {
		var shakers = GameObject.FindObjectsOfType<TileIntro>();
		foreach(var s in shakers) {
			s.Shake();
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if( c.gameObject.CompareTag("Blocker")) {
			ScreenShake.MainShake();
			ShakeTiles();
			AudioSource.PlayClipAtPoint(SoundBlocker, new Vector3(0,0,0));
			Flash();
		}

		else if(c.gameObject.CompareTag("Tile")) {
			AudioSource.PlayClipAtPoint(SoundTile, new Vector3(0,0,0));
			Flash();
		}
		else if(c.gameObject.CompareTag("Paddle")) {
			var pm = c.gameObject.GetComponent<PaddleMovement>();
			AudioSource.PlayClipAtPoint(SoundPaddle, new Vector3(0,0,0));
			ShakeTiles();
			Flash();
			this.b.velocity = new Vector2(b.velocity.x + pm.GetHorMov()*1.5f, b.velocity.y);
		}
	}
}
