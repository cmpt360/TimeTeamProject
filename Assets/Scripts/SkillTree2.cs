using UnityEngine;
using System.Collections;

public class SkillTree2: MonoBehaviour {
	
	// connect skilltree to stat class
	public StatCollectionClass stat;
	
	//skill level
	public int maxEnergyBallLv=5;
	//xp cost
	public int EnergyBallPrice=30;
	//mana cost
	public float EnergyBallMpCost = 5f;
	//use for skill grow
	int i =0;
	
	//sample of second skill
	public int maxFireBreathLv=5;
	public int FireBreathPrice=60;
	public float FireBreathMpCost = 10f;
	public float FireBreathDamage = 120f;
	int j =0;
	
	//sample of third skill
	public int maxSunStrikeLv=5;
	public int SunStrikePrice=120;
	public float SunStrikeMpCost = 20f;
	public float SunStrikeDamage = 300f;
	int k =0;
	
	// create GUI Button on panel
	void OnGUI () {
		//set the location of button
		if (GUI.Button (new Rect (400, 50, 120, 30), "Energy Ball Lv" + i)) {
			//skill level must lower than max level
			if (i < maxEnergyBallLv) {
				// player's xp value max higher than skill xp cost
				if (stat.xp >= EnergyBallPrice) {
					//set skill actived
					stat.EnergyBallUnlocked = true;
					//cost the player's xp by skill xp cost value
					stat.xp -= EnergyBallPrice;
					//level up
					i++;
					//each skill value increase with the level
					EnergyBallPrice *=i+1;
					EnergyBallMpCost *=i;
					stat.EnergyBalldamage+=10f;
					
					
					
					
				} else if (stat.xp < EnergyBallPrice) {
					Debug.Log ("not enouph xp");
				}
			} else {
				Debug.Log ("max skill level");
			}
			
		}
		//same as 1st skill
		if (GUI.Button (new Rect (400, 150, 120, 30), "Fire Breath Lv" + j)) {
			if (i == maxEnergyBallLv) {
				if (j < maxFireBreathLv) {
					
					if (stat.xp >= FireBreathPrice) {
						stat.FireBreathUnlocked = true;
						stat.xp -= FireBreathPrice;
						j++;
						FireBreathPrice *= j+1;
						FireBreathMpCost *=j;
						FireBreathDamage *=j;
						
						
						
					} else if (stat.xp < FireBreathPrice) {
						Debug.Log ("not enouph xp");
					}
				} else {
					Debug.Log ("max skill level");
				}
				
			}
			else 
			{
				Debug.Log (" need previous skill");
			}
		}
		
		//same as 1st skill
		if (GUI.Button (new Rect (400, 250, 120, 30), "Sun Strike Lv" + k)) {
			
			if (j == maxFireBreathLv) {
				
				if (k < maxSunStrikeLv) {
					
					if (stat.xp >= SunStrikePrice) {
						stat.SunStrikeUnlocked = true;
						stat.xp -= SunStrikePrice;
						k++;
						SunStrikePrice *= k+1;
						SunStrikeMpCost *=k;
						SunStrikeDamage *=k;
						
						
						
					} else if (stat.xp < SunStrikePrice) {
						Debug.Log ("not enouph xp");
					}
				} else {
					Debug.Log ("max skill level");
				}
				
			}
			else 
			{
				Debug.Log (" need previous skill");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
}
