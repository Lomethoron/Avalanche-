using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //moving down does nothing
        if(move.y < 0) {
            move.Set(move.x, 0, 0);
        }
        //jump
        if (move.y > 0) {
            move.Set(move.x, 2*move.y, 0);
        }
            transform.position += move * speed * Time.deltaTime;

    }
}
