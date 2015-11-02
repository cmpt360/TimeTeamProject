using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    public GameObject playerSpawn;
    GameObject playerObject;
    float respawnTime;
	// Use this for initialization
	void Start () {
        //create player when the game start
        respawnPlayer();
	}
    void respawnPlayer()
    {
        respawnTime = 2;
        playerObject = (GameObject)Instantiate(playerSpawn, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update () {
        //if the player is die
	if(playerObject == null)
        {
            respawnTime -= Time.deltaTime;
            if(respawnTime <= 0)
            {
                respawnPlayer();
            }

        }
    }
}
