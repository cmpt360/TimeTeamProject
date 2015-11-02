using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    public GameObject playerSpawn;
    GameObject playerObject;
    float respawnTime;
    public GameObject deadsound;
    
    //lives is how many time player can respawn
    public int lives = 4; // will have 3 lives since in the begin it will decrease one already
	// Use this for initialization
	void Start () {
        //create player when the game start
        respawnPlayer();
	}
    void respawnPlayer()
    {
        // just respawn player
        lives--;
        // set up respawn time is one
        respawnTime = 1;
        playerObject = (GameObject)Instantiate(playerSpawn, transform.position, Quaternion.identity);
        //create game object
        if(lives != 3)
        {
            Instantiate(deadsound);
        }
        
        

    }

    // Update is called once per frame
    void Update () {
        //if the player is die
	if(playerObject == null && lives > 0)
        {
            // this will count down one second after one second player will respawn
            respawnTime -= Time.deltaTime;
            if(respawnTime <= 0)
            {
                respawnPlayer();
                
            }

        }
    }


    void OnGUI()
    {
        //show on the left top how many lives left
        if (lives > 0 || playerObject != null)
        {
            GUI.Label(new Rect(10, 60, 40, 50), "  lives:" + lives);
        }


        //if there is no lives leave and player is die show gameover
        else
        {
            GUI.Label(new Rect(Screen.width/2,Screen.height/2-25, 100, 50), " Game Over ");
        }
    }

}
