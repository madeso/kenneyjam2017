﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {
	public GameObject Tile;
	public float TileWidth = 1;
	public float TileHeight = 1;

	public int Height = 3;
	public int Width = 5;

	void SpawnTiles()
	{
		for(int x=0; x<this.Width; x += 1) {
			for(int y=0; y<this.Height; y += 1) {
				var xpos = this.transform.position.x + x*this.TileWidth;
				var ypos = this.transform.position.y + y * this.TileHeight;
				GameObject.Instantiate(this.Tile, new Vector3(xpos, ypos), Quaternion.identity);
			}
		}
	}

	// Use this for initialization
	void Start () {
		this.SpawnTiles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
