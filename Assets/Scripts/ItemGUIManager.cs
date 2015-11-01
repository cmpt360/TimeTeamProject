using UnityEngine;
using System.Collections;

public class ItemGUIManager : MonoBehaviour {

	//access to class State
	public StatCollectionClass stat;

	//3 item we need to manager now
	public GameObject Sword;

	public GameObject Armor;

	public GameObject Bow;

	void Update ()
	{     
		// show the picture on the scene if player got the item
		Sword.SetActive(stat.itemSword);
			
		Armor.SetActive (stat.itemArmor);

		Bow.SetActive (stat.itemBow);

	}
}
