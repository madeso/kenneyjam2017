﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOutside : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "PlayArea")
		{
			Destroy(this.gameObject);
		}
	}
}
