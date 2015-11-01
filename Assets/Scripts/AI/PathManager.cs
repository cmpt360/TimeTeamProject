using UnityEngine;
using System.Collections;

public class PathManager : MonoBehaviour {

	bool obstacle;		//Flag if an obstacle has been hit.
	bool pause = false; //Flag if entity is pathing a random distance. Pauses other pathing logic temporarily.
	Vector3 player;		//The player position vector.
	public float mobSp;	//Keep a record of the spawn location, so we can return to it if necessary.

	void Start () {
	
	}


	void Update () {
		//PathToTarget ("Player");
	}


	////////////////////////	////////////////////////////////////////////////////////////////////////////////////////
	/* 
		Point towards and move towards target. If theres a collision with a map object, walk a random direction and 
		try again.
		Tags in the string of the tag of the object to path towards
		TODO Target picking logic if theres more then one entity with that tag.
	*/
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////
	public void LocalPathToTarget(string tag){
		player = GameObject.FindWithTag (tag).transform.localPosition;
		if (!obstacle) {
			float rotZ = Mathf.Atan2 (player.y - transform.position.y, player.x - transform.position.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (rotZ, Vector3.forward);
		} else if (obstacle && !pause) {
			//print ("Going random angle");
			float randomAng = Random.Range (-90.0f, 90.0f);
			//print ("I picked: " + randomAng + "!");
			transform.rotation = Quaternion.AngleAxis (Random.Range (-90.0f, 90.0f), Vector3.forward);
			pause = true;
		}
		//print ("moving forward");
		transform.Translate (Vector3.right * mobSp * Time.deltaTime);
	}


	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/* 
		TODO The function to handle global pathing. Room to room, area to area pathing.
		This will be implemented with a static map (static after random generation).
		Each component will have premade nodes and we will construct a joining algorith that adds edges or combines
		nodes on our prefab map pieces/regions depending how they end up connected.
		This function will call localPathToTarget for the closest node.
		Then the entity will path along the graph to its exit node.
		If our graph is of the correct form, we can use A* to make path decisions.
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	public void GlobalPathToTarget(){
	}


	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/* 
		TODO The function to head back to the spawn location, using both global and local pathing.
		This function is to prevent kiting. (Dragging enemies into obstacles, keeping them at range, etc.)
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	public void GoToSpawn(){
	}


	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/* 
		The collision handler for pathing.
		If a collision occurs and we aren't global pathing (TODO) we walk a random direction and try and transit to
		node/target again.
		If we are global pathing, our global pathing graph has an issue.
		Throw an error.
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	void OnCollisionEnter2D(Collision2D collision)
	{
		//TODO Tags need to be adjusted for all collidables.
		if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" ) {
		StartCoroutine(waitForMove ());

		}
	}


	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/* 
		Wait to allow object to move away from obstacle (hopefully). Then try and resume following player.
		This is a helper function for localPathToTarget()
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	IEnumerator waitForMove()
	{
		//print ("waiting to change direction");
		obstacle = true;
		pause = false;
		yield return new WaitForSeconds(4);
		obstacle = false;
		//print ("finished changing direction");
	}

}
