using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CratePhysics : MonoBehaviour {

    public bool grounded;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name.Equals("Ground")) {
            rb.bodyType = RigidbodyType2D.Static;
            grounded = true;
        }
        else if (collision.gameObject.name.Equals("Crate(Clone)") && collision.gameObject.GetComponent<CratePhysics>().grounded) {
            rb.bodyType = RigidbodyType2D.Static;
            grounded = true;
        }
    }
    void OnCollisionStay2D(Collision2D collision) {
        
    }
    void OnCollisionExit2D() {
        
    }
}
