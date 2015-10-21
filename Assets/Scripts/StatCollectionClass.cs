using UnityEngine;
using System.Collections;

// This class holds the various stats that will be used by the player and enemies in our game
// Each object will have their own version of a stat collection
public class StatCollectionClass : MonoBehaviour {

	public float health;
			
	public float mana;
			
	public int strength;
			
	public int intellect;
			
	public int xp;
			
	public int playerLevel;

	public bool itemCoin;

	public bool EnergyBallUnlocked;

	public float EnergyBalldamage;

	public bool FireBreathUnlocked;

	public bool SunStrikeUnlocked;
}

