using UnityEngine;
using System.Collections;

public class ItemArmor : MonoBehaviour {

	public StatCollectionClass stat;

	//give armor a value of defend
	public float ArmorDef = 50f;
	
	void OnTriggerEnter2D(Collider2D other) {  
		
		
		
		// If player collided with item armor
		if (other.tag == "Player") {
			
			// set item armor unlocked
			stat.itemArmor = true;

			//if not equipment now just equip it
			if(stat.SwordEquip ==false && stat.BowEquip==false)
			{
				//add player defend with armor defend
				stat.defend+=ArmorDef;
				//set armor equip true
				stat.ArmorEquip = true; 	
			}
			// Destroy the item
			Destroy(this.gameObject);
			
			
			
		}
	}
}
