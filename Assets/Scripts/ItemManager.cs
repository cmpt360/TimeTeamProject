using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	public StatCollectionClass stat;





	void OnTriggerEnter2D(Collider2D other) {  


		
		// If it collided with item1
		if (other.tag == "Player") {



			// set item1 unlocked
			stat.itemCoin = true;


		//	GlobalVariables.CoinNum ++;

			// Destroy the item
			Destroy(this.gameObject);

			

		}
	}
}
