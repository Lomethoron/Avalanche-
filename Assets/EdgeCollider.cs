using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//track which side this collider is and inform the parent script when a collision has occured
public class EdgeCollider : MonoBehaviour {

    
    private Player.Side side;

	// Use this for initialization
	void Start () {
        if( name.Equals("Left Collider")) {
            side = Player.Side.Left;
        }
        else if (name.Equals("Right Collider")) {
            side = Player.Side.Right;
        }
        else if (name.Equals("Top Collider")) {
            side = Player.Side.Top;
        }
        else if (name.Equals("Bottom Collider")) {
            side = Player.Side.Bottom;
        }
        else{
            side = Player.Side.None;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay2D(Collision2D collision) {
        print("Player colliding with " + collision.gameObject.name + " on the " + side + " side.");
        transform.parent.gameObject.GetComponent<Player>().collisionEnter(side, collision);

    }
}
