using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

    private Spawner spawner;
    private GameObject gameOverModal;

	// Use this for initialization
	void Start () {
        //get the gameobject and then cast to its child type
        spawner = GameObject.FindWithTag("Spawner").GetComponent<Spawner>();
        gameOverModal = GameObject.Find("Game Over Modal");
        //Set the simulation time for the reset
        //TODO:There should probably be a more advanced way of handling this rather than freezing the whole scene
        Time.timeScale = 1;

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
        gameOverModal.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void reset() {
        SceneManager.LoadScene("Climber");
    }
}
