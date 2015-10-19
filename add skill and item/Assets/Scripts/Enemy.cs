using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private GameObject target;

	private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player");
		rBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Enemy will follow the player
		if (target != null) {
			float angl = Mathf.Atan2 (target.transform.position.y - this.transform.position.y, target.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
			rBody.MoveRotation (angl);
			CustomFunctions.SetVel (rBody, 0.5f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {  
		string tag = other.gameObject.tag;

		// If it collided with an enemy
		if (tag == "Player") {

			// Destroy the player
			Destroy (other.gameObject);

			// Restart the level in 1 seconds
			Invoke("Reset", 1f);
		}
	}

	// Restart level
	void Reset(){
		GlobalVariables.kills = 0;
		Application.LoadLevel(Application.loadedLevel);
	}
}
