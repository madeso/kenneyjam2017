using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOutside : MonoBehaviour {
	bool outside = false;
	public float life = 2.0f;

	public bool IsOutside
	{
		get{
			return this.outside;
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(outside) {
			this.life -= Time.deltaTime;
		}

		if(this.life < 0 ) 
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "PlayArea")
		{
			outside = true;
		}
	}
}
