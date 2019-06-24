using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

    private Spawner spawner;

	// Use this for initialization
	void Start () {
        //get the gameobject and then cast to its child type
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //On game loss
    public void loseGame() {
        //end player control
        Time.timeScale = 0;
        //stop the crates spawning
        spawner.stopSpawning();
        //display game over

    }
}
