using UnityEngine;
using System.Collections;

public class EnergyBallExplo : MonoBehaviour {

	public StatCollectionClass enemyStat;

	GameObject player;
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


		if (col.gameObject.tag == "Enemy") {

			enemyStat = col.GetComponent<StatCollectionClass>();

			enemyStat.health-=playerStat.EnergyBalldamage;

			if(enemyStat.health <= 0)
			{
				Destroy(col.gameObject);
			}
			
			Destroy (gameObject);




		} 
		
		if (col.gameObject.tag == "wallTop"||col.gameObject.tag == "wallBottom"
		    ||col.gameObject.tag == "wallLeft"|| col.gameObject.tag == "wallRight"
		    ||col.gameObject.tag == "Obstacle") {
			
			Destroy (gameObject);

			
		}

	}
}
