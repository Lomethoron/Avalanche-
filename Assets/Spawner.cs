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
    private float spawnRate;

    // Use this for initialization
    void Start () {
        rand = new System.Random();
        screenLeftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x;
        screenRightEdge = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).x;
        screenTopEdge = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).y;
        spawnRate = .02f;
    }
	
	// Update is called once per frame
	void Update () {
        screenTopEdge = Math.Max(screenTopEdge, cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).y);
        float spawnValue = (float) rand.NextDouble();
        int boxesToSpawn = rand.Next(0, 2);
        if (spawnValue < spawnRate) {
            while (boxesToSpawn > 0) {
                float spawnInset = (Math.Abs(screenRightEdge) + Math.Abs(screenLeftEdge)) / 8;
                // formula for random value with in a range
                // between 1/8 from both screen edges
                float spawnXPos = (screenLeftEdge + spawnInset) + ((float)rand.NextDouble()) * ((screenRightEdge - spawnInset) - (screenLeftEdge + spawnInset));
                float spawnYPos = screenTopEdge + 10f;
                float scale = rand.Next(16, 32);
                Instantiate(crate);
                crate.transform.position = new Vector3(spawnXPos, spawnYPos, 0);
                crate.transform.localScale = new Vector3(scale, scale, 0);
                boxesToSpawn--;
            }
        }
	}

    public void stopSpawning() {
        spawnRate = 0;
    }
}
