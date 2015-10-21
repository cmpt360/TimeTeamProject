using UnityEngine;
using System.Collections;

public class EnergyBallExplo : MonoBehaviour {

	//need 2 state collection this one is for enemy state
	public StatCollectionClass enemyStat;

	GameObject player;
	//this one is for player state
	StatCollectionClass playerStat;


	
	//AudioSource audio;
	
	void Start () 
	{

		player = GameObject.FindWithTag ("Player");

		playerStat = player.GetComponent<StatCollectionClass >();

		Destroy(gameObject, 3f);
		
	}
	
	
	void OnTriggerEnter2D(Collider2D col)
	{

		// if collided with enemy
		if (col.gameObject.tag == "Enemy") {

			enemyStat = col.GetComponent<StatCollectionClass>();
			// damage enemy with the skill damage
			enemyStat.health-=playerStat.EnergyBalldamage;

			//destroy enemy if hp less than or equal to 0
			if(enemyStat.health <= 0)
			{
				Destroy(col.gameObject);
			}

			//destroy the skill prefabs
			Destroy (gameObject);




		} 

		// if collided with obstacle or wall 
		if (col.gameObject.tag == "Wall" ||col.gameObject.tag == "Obstacle") {

			//destroy the skill prefabs
			Destroy (gameObject);

			
		}

	}
}
