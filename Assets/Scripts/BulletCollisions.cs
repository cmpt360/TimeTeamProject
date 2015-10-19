using UnityEngine;
using System.Collections;

public class BulletCollisions : MonoBehaviour {

	StatCollectionClass enemyStat;
	GameObject player;
	StatCollectionClass playerStat;
	Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		playerStat = player.GetComponent<StatCollectionClass> ();
		rBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rBody.velocity *= 1.01f;
	}

	void OnTriggerEnter2D(Collider2D other) {  
		string tag = other.gameObject.tag;
		
		// If it collided with an enemy
		if (tag == "Enemy") {

			//Damage enemy
			//enemy health -= player attack;
			// Destroy the enemy
			enemyStat = other.GetComponent<StatCollectionClass>();
			enemyStat.health = enemyStat.health - playerStat.intellect;
			if(enemyStat.health <= 0)
			{
				Destroy(other.gameObject);
			}
			
			// And destroy the bullet
			Destroy(this.gameObject);
		}
        if (tag == "Wall" || tag == "Obstacle")
        {
			//Destroy the bullet
            Destroy(this.gameObject);
        }
	}
}

