using UnityEngine;
using System.Collections;

public class ItemBow : MonoBehaviour {

	
	public StatCollectionClass stat;

	//give a damage value to bow
	public float BowDamage = 50f;
	
	void OnTriggerEnter2D(Collider2D other) {  
		
		
		
		// If player collided with bow
		if (other.tag == "Player") {
			
			// set item bow unlocked
			stat.itemBow = true;

			if(stat.ArmorEquip==false && stat.SwordEquip==false)
			{
			
				//add player attack damage with bow damage
				stat.damage+=BowDamage;

				stat.BowEquip =true;
			}
			
			// Destroy the item
			Destroy(this.gameObject);
			
			
			
		}
	}
}
