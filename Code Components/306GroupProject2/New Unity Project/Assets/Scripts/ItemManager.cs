using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	public StatCollectionClass stat;





	void OnTriggerEnter2D(Collider2D other) {  


		
		// If it collided with coin
		if (other.tag == "Player") {



			// set coin unlocked
			stat.itemCoin = true;

			// increase coin count
			GlobalVariables.CoinNum ++;

			// Destroy the coin
			Destroy(this.gameObject);

			

		}
	}
}
