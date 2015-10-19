using UnityEngine;
using System.Collections;

public class BulletCollisions : MonoBehaviour {

	Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
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
			GlobalVariables.kills++;

			// Destroy the enemy
			Destroy (other.gameObject);
			
			// And destroy the bullet
			Destroy(this.gameObject);
		}
        if (tag == "Wall")
        {
			//Destroy the bullet
            Destroy(this.gameObject);
        }
	}
}

