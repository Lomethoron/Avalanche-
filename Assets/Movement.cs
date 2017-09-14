using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 10f;
    public float jump = 15f;
    public float jumpMultiplier = 3;
    public Camera cam;
    public EdgeCollider2D leftCollider, rightCollider, topCollider, bottomCollider;

    public enum Side { Left, Right, Top, Bottom, None };

    private float playerOffset;
    private Rigidbody2D rb;
    private Collider2D col;
    private Vector3 movement;
    private float screenLeftEdge, screenRightEdge, playerXOffset;
    private Side side = Side.None;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        screenLeftEdge = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x;
        screenRightEdge = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).x;

        // extents is always half the size of the object
        playerXOffset = col.bounds.extents.x;
        Destroy(col);

    }
	
	// Update is called once per frame
    void Update() {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (Input.GetButtonDown("Jump")) print("Grounded on the " + side + " side." + "\nVector is " + movement);
        if (Input.GetButtonDown("Jump") && side != Side.None) {
            switch (side) {
                case Side.Left:
                    movement.x = jump;
                    movement.y = jumpMultiplier * jump;
                    side = Side.None;
                    break;
                case Side.Right:
                    movement.x = -jump;
                    movement.y = jumpMultiplier * jump;
                    side = Side.None;
                    break;
                case Side.Top:
                    break;
                case Side.Bottom:
                    movement.y = jumpMultiplier * jump;
                    side = Side.None;
                    break;
                case Side.None:
                default:
                    break;
            }
            //rb.AddForce(movement * speed);
            if (Input.GetButtonDown("Jump")) print("Grounded on the " + side + " side." + "\nVector is now " + movement);
        }
    }

    // FixedUpdate is called at a constant rate independent of framerate
	void FixedUpdate () {
        rb.AddForce(movement * speed);

        // clamp to screen
        float playerLeftEdge = rb.position.x - playerXOffset;
        float playerRightEdge = rb.position.x + playerXOffset;
        // extents is always half the size of the object
        if (playerLeftEdge <= screenLeftEdge) {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.position = new Vector3(screenLeftEdge + playerXOffset, rb.position.y, 0);
        }
        if (playerRightEdge >= screenRightEdge) {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.position = new Vector3(screenRightEdge - playerXOffset, rb.position.y, 0);
        }

    }

    public void collisionEnter(Side side, Collision2D other) {
        print("function?");
        switch (side) {
            case Side.Left:
                this.side = Side.Left;
                //rb.velocity = new Vector3(0, 0, 0);
                break;
            case Side.Right:
                this.side = Side.Right;
                //rb.velocity = new Vector3(0, 0, 0);
                break;
            case Side.Top:
                this.side = Side.Top;
                if (other.collider.name.Equals("Crate(Clone)")) {
                    Time.timeScale = 0;
                }
                break;
            case Side.Bottom:
                this.side = Side.Bottom;
                //rb.velocity = new Vector3(0, 0, 0);
                break;
            case Side.None:
            default:
                print("Iceburg struck! Collision with unknown object!");
                break;
        }
    }
}
