using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 10f;
    public float jump = 15f;
    public Camera cam;

    private bool collided = false;
    private float playerOffset;
    private Rigidbody2D rb;
    private Collider2D col;
    private Vector3 movement;
    private float screenLeftEdge, screenRightEdge;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        screenLeftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x;
        screenRightEdge = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).x;
        //playerOffset = transform.right.x * (transform.localScale.x / 2f);
        //print("Transform.right.x: " + transform.right.x);
        //print("Transform.localScale.x: " + transform.localScale.x);
        //print("Transform.position.x: " + transform.position.x);

    }
	
	//Update is called once per frame
    void Update() {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (Input.GetButton("Jump") && collided) {
            movement.y = jump;
        }
    }

    //FixedUpdate is called at a constant rate independent of framerate
	void FixedUpdate () {
        rb.AddForce(movement * speed);

        // clamp to screen
        float playerLeftEdge = col.bounds.min.x;
        float playerRightEdge = col.bounds.max.x;
        float playerXOffset = col.bounds.extents.x;
        if (playerLeftEdge <= screenLeftEdge) {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.position = new Vector3(screenLeftEdge + playerXOffset, rb.position.y, 0);
        }
        if (playerRightEdge >= screenRightEdge) {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.position = new Vector3(screenRightEdge - playerXOffset, rb.position.y, 0);
        }

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
