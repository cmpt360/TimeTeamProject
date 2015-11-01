using UnityEngine;
using System.Collections;

public class PlayerStateGUI : MonoBehaviour {

	// connect stateGUI to stat class
	public StatCollectionClass stat;

	//create gui for each state
	void OnGUI () {

		GUI.TextArea (new Rect (400, 50, 120, 30), "Level" + stat.playerLevel);

		GUI.TextArea (new Rect (400, 100, 120, 30), "Xp" + stat.xp);
		
		GUI.TextArea (new Rect (400, 150, 120, 30), "Health: " + stat.health);

		GUI.TextArea (new Rect (400, 200, 120, 30), "Mana: " + stat.mana);

		GUI.TextArea (new Rect (400, 250, 120, 30), "Damage: " + stat.damage);

		GUI.TextArea (new Rect (400, 300, 120, 30), "defend: " + stat.defend);

		GUI.TextArea (new Rect (400, 350, 120, 30), "Strength: " + stat.strength);

		GUI.TextArea (new Rect (400, 400, 120, 30), "Intellect: " + stat.intellect);

	}

}
