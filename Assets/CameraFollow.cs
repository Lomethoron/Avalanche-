using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float playersAhead = 10;
    private float cameraForwardOffset;
	// Use this for initialization
	void Start () {
        cameraForwardOffset = playersAhead * target.GetComponent<Renderer>().bounds.size.y;
        print(target.GetComponent<Renderer>().bounds.size.y);
        print(cameraForwardOffset);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, target.position.y + cameraForwardOffset, transform.position.z);
	}
}
