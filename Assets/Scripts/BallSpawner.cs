using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
	public Rigidbody2D BallToSpawn;
	public GameObject SpawnPosition;

	public AudioClip SoundSpawn;

	void Start () {
		
	}
	
	void Update () {
		bool canSpawn = GameObject.FindGameObjectsWithTag("Ball")
			.Where(x=>x.GetComponent<KillOutside>().IsOutside == false)
			.FirstOrDefault() == null;
		var r = SpawnPosition.GetComponent<SpriteRenderer>();
		r.enabled = canSpawn;
		if( canSpawn ) {
			if( Input.GetKeyDown(KeyCode.LeftControl) ) 
			{
				AudioSource.PlayClipAtPoint(SoundSpawn, new Vector3(0,0,0));
				var ball = GameObject.Instantiate(BallToSpawn);
				ball.transform.position = this.SpawnPosition.transform.position;
				ball.AddForce(new Vector2(0, 300));
			}
		}
	}
}
