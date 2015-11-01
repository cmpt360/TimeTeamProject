using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemState : MonoBehaviour {
	// this class use to describe item's state
	public StatCollectionClass stat;

	Text txt;
	
	void Start () {
		txt = gameObject.GetComponent<Text>();
	}
	
	
	void Update () {
		

		if (stat.ArmorEquip == true) {
			txt.text = "Armor: defend +50";
		}

		if (stat.SwordEquip == true) {
			txt.text = "Sword: damage +100";
		}

		if (stat.BowEquip == true) {
			txt.text = "Bow: damage +50";
		}
	}
}
