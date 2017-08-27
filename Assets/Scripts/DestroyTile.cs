using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		print(coll.gameObject.tag);
		if(coll.gameObject.tag == "Ball") {
			Destroy(this.gameObject);
		}
	}
}
