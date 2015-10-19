using UnityEngine;
using System.Collections;

public class PathManager : MonoBehaviour {

	bool obstacle;
	bool pause = false;
	Vector3 player;
	public float mobSp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//PathToTarget ("Player");
	
	}

	//Point towards and move towards target. If theres a collision with a map object, walk a random direction and try again.
	//Tags in the string of the tag of the object to path towards
	//TODO Target picking logic if theres more then one entity with that tag.
	public void PathToTarget(string tag){
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

	//Wait to allow object to move away from obstacle (hopefully). Then try and resume following player.
	IEnumerator waitForMove()
	{
		//print ("waiting to change direction");
		obstacle = true;
		pause = false;
		yield return new WaitForSeconds(4);
		obstacle = false;
		//print ("finished changing direction");
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//TODO Tags need to be adjusted for all collidables.
		if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" ) {
		StartCoroutine(waitForMove ());

		}
	}

}
