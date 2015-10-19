using UnityEngine;
using System.Collections;

public class EnergyBallExplo : MonoBehaviour {



	
	//AudioSource audio;
	
	void Start () 
	{
		
		Destroy(gameObject, 3f);
		
	}
	
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			
			
			
			Destroy (gameObject);


		} 
		
		if (col.gameObject.tag == "Outwall") {
			
			Destroy (gameObject);

			
		}

		if (col.gameObject.tag == "Obsker") {
			
			Destroy (gameObject);
			
			
		}
	}
}
