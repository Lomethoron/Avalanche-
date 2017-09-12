using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Camera cam;
    public GameObject crate;
    //C# random
    private System.Random rand;
    private float screenLeftEdge, screenRightEdge, screenTopEdge, spawnLeftEdge, spawnRightEdge;

    // Use this for initialization
    void Start () {
        rand = new System.Random();
        screenLeftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x;
        screenRightEdge = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).x;
        screenTopEdge = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).y;
    }
	
	// Update is called once per frame
	void Update () {
        screenTopEdge = Math.Max(screenTopEdge, cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).y);
        int spawnValue = rand.Next(0, 40);
        //0,1 no cubes, 3 one cube, 4 two cubes
        for( spawnValue = Math.Max(spawnValue-38, 0); spawnValue > 0; spawnValue--) {
            float spawnInset = Math.Abs(screenRightEdge) + Math.Abs(screenLeftEdge) / 8;
            // formula for random value with in a range
            // between 1/8 from both screen edges
            float spawnXPos = (screenLeftEdge + spawnInset) + ((float)rand.NextDouble()) * ((screenRightEdge - spawnInset) - (screenLeftEdge + spawnInset));
            float spawnYPos = screenTopEdge + 10f;
            float scale = rand.Next(8, 32);
            Instantiate(crate);
            crate.transform.position = new Vector3(spawnXPos, spawnYPos, 0);
            crate.transform.localScale = new Vector3(scale, scale, 0);
        }
	}
}
