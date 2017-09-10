using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 6.0f;
    public bool collided = false;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (Input.GetButtonDown("Jump") && collided) {
            move.y = 100.0f;
        }
        rb.AddForce(move * speed);

    }
    void OnCollisionEnter2D(Collision2D collision) {
        print("Entered collision");
        collided = true;
    }
    void OnCollisionStay2D(Collision2D collision) {
        collided = true;
    }
    void OnCollisionExit2D() {
        collided = false;
    }
}
