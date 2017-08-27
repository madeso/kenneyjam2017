using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
	public float Intensitiy = 1.0f;
	float timer = 0;
	public float TimeBetweenShakes = 0.1f;

	float timerIntensity = 0;
	public float ShakeTime = 0.5f;

	// Use this for initialization
	void Start () {
		
	}

	public void Shake()
	{
		timerIntensity = ShakeTime;
	}

	public static void MainShake()
	{
		Camera.main.GetComponent<ScreenShake>().Shake();
	}

	float R(float f)
	{
		return Random.Range(-f, f);
	}
	
	// Update is called once per frame
	void Update () {
		timerIntensity -= Time.deltaTime;
		timer += Time.deltaTime;
		if(timerIntensity > 0){
			if(timer > this.TimeBetweenShakes ) {
				timer -= this.TimeBetweenShakes;
				float i = this.Intensitiy * timerIntensity/ShakeTime;
				this.transform.localPosition = new Vector2(R(i), R(i));
			}
		}
		else {
			timerIntensity = 0;
			timer = 0;
			this.transform.transform.localPosition = new Vector2(0,0);
		}
	}
}
