using UnityEngine;
using System.Collections;

public class ItemEquipManager : MonoBehaviour {

	//access to state class
	public StatCollectionClass stat;

	//now we have 3 item to equip
	public GameObject Sword;
	
	public GameObject Armor;
	
	public GameObject Bow;

	// set input key
	public string InputKey;
	
	void Update ()
	{     

		//if player have any item already equiped show it on the scene
		Sword.SetActive(stat.SwordEquip);
		
		Armor.SetActive (stat.ArmorEquip);
		
		Bow.SetActive (stat.BowEquip);

		// put the key to switch items
		if(Input.GetButtonDown (InputKey))
		{
			//when sword is already equiped
			if(stat.SwordEquip==true)
			{
				//and we have item armor unlocked
				if(stat.itemArmor == true)
				{
					//take off sword
					stat.SwordEquip =false;

					//equip armor
					stat.ArmorEquip =true;

					//adjust player state
					stat.damage-=100f;

					stat.defend+=50f;

					//adjust item show on the scene
					Sword.SetActive(false);

					Armor.SetActive (true);
				}

				//player dont unlocked armor but unlocked bow
				else if(stat.itemBow==true)
				{
					//adjust player state
					stat.SwordEquip =false;
					
					stat.BowEquip =true;
					
					stat.damage-=50f;
					
					Sword.SetActive (false);
					
					Bow.SetActive(true);
				}
			}

			//player equiped armor
			else if(stat.ArmorEquip==true)
			{
				//player have item bow 
				if(stat.itemBow==true)
				{
					//adjust player state
					stat.ArmorEquip =false;
				
					stat.BowEquip =true;
				
					stat.damage+=50f;
				
					stat.defend-=50f;
				
					Armor.SetActive (false);

					Bow.SetActive(true);
				}
				//player dont have bow but have sword
				else if(stat.itemSword ==true)
				{
					//adjust player state
					stat.ArmorEquip =false;
					
					stat.SwordEquip =true;
					
					stat.damage+=100f;

					stat.defend-=50;
					
					Sword.SetActive (true);
					
					Armor.SetActive(false);
				}
			}

			// player equiped bow
			else if(stat.BowEquip==true)
			{
				//player have item sword 
				if(stat.itemSword==true)
				{
					//adjust player state
					stat.BowEquip =false;
				
					stat.SwordEquip =true;
				
					stat.damage+=50f;
				
					Sword.SetActive (true);
				
					Bow.SetActive(false);
				}
				//player dont have item sword but have armor
				else if(stat.itemArmor==true)
				{
					//adjust state
					stat.BowEquip =false;
					
					stat.ArmorEquip =true;
					
					stat.damage-=50f;
					
					stat.defend+=50f;
					
					Bow.SetActive(false);
					
					Armor.SetActive (true);
				}
			}
		
	}
}
}
