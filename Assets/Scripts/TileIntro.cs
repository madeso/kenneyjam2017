using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileIntro : MonoBehaviour {
	public float WaitMax = 1.0f;
	public float AnimationScale = 1.0f;
	Vector2 start;
	Vector2 end;
	float t = 0;
	float wait;

	Rigidbody2D rb;

	public Sprite[] Sprites;

	// Use this for initialization
	void Start () {
		var sp = GetComponent<SpriteRenderer>();
		sp.sprite = Sprites[Random.Range(0, Sprites.Length)];

		var sy = GameObject.Find("StartY");

		rb = this.GetComponent<Rigidbody2D>();
		var p = this.transform.position;
		this.start = new Vector2(p.x, sy.transform.position.y);
		this.end = new Vector2(p.x, p.y);
		this.wait = Random.Range(0, this.WaitMax);

		this.rb.MovePosition(this.start);
		// this.transform.position = this.start;
	}

	float Inter(float st, float t, float en)
	{
		float v = Easings.Interpolate(t, Easings.Functions.ElasticEaseOut);
		return st + v*( en-st );
	}

	bool done = false;
	Vector2 basePosition;
	float shakeTimer = 0;

	float RandomShake() {
		float rb = 0.05f;
		return Random.Range(-rb*shakeTimer, rb*shakeTimer);
	}
	
	// Update is called once per frame
	void Update () {
		if( wait > 0 )
		{
			wait -= Time.deltaTime;
		}
		else if(done == false) {
			t += Time.deltaTime * this.AnimationScale;
			if( t > 1.0f ) {
				t = 1.0f;
				done = true;
			}

			float x = Inter(start.x, t, end.x);
			float y = Inter(start.y, t, end.y);

			if(done) {
				basePosition = new Vector2(x,y);
			}

			// this.transform.localPosition = new Vector2(x, y);
			this.rb.MovePosition(new Vector2(x,y));
		}
		else {
			shakeTimer -= Time.deltaTime * 3;
			if(shakeTimer > 0){
				this.rb.MovePosition(basePosition + new Vector2(RandomShake(),RandomShake()));
			}
			else {
				this.rb.MovePosition(basePosition);
			}
		}
	}

	public void Shake() {
		this.shakeTimer = 1;
	}
}
