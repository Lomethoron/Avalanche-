using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 10f;
    public float jump = 15f;
    public Camera cam;

    private bool collided = false;
    private float playerOffset;
    private Rigidbody2D rb;
    private Vector3 movement;
    private float screenLeftEdge, screenRightEdge;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        screenLeftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x;
        screenRightEdge = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).x;
        playerOffset = transform.right.x * (transform.localScale.x / 2.0f);

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
        float playerLeftEdge = transform.position.x - playerOffset;
        float playerRightEdge = transform.position.x + playerOffset;
        if (playerLeftEdge <= screenLeftEdge) {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.position = new Vector3(screenLeftEdge + playerOffset, rb.position.y, 0);
        }
        if (playerRightEdge >= screenRightEdge) {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.position = new Vector3(screenRightEdge - playerOffset, rb.position.y, 0);
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
