using UnityEngine;
using System.Collections;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/* 	
 	At startup this struct is populated with AI parameters. 
  	These are simple booleans to describe the AI classificaiton.
	ie. Melee = true, Aggressive = true, Stalker = true
	These booleans will describe the behavior and help construct the decision tree Psuedo-dyanamically.
  	If nothing else(dynamic explodes on us), it will describe the piece-wise template they adhere to.
  	TODO
	Parameters have to be decided on.
*/
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public struct AIConfig {
	public bool isMelee;		//Will favour melee attacks over ranged. Should default to ranged if melee is not possible.
								//If false the enemy will favour ranged attacks, and use melee or run if the player does.
	public bool isAggressive;	//The enemy will attack first and from a greater distance.

	public bool isStalker;		//No jokes. The enemy follows the player further then other AI.

	public bool hasMagic;		//Has magic abilities, will reference a list in attack and use them on conditions.

	public bool isCautious;	//If the AI has low health, the AI will run away if possible. Use defensive abilities/heal.

	public bool isMade;		//This AI Configuration was successfully setup.	
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/* 
	This class pulls together all the scripts and methods that will comprise our AI.The basics are laid out here
	since this is a fairly hefty code set.
	
	This script is attached to a prefab and startup will assign stats and behavior, randomly, or specified(TODO).

	Pathing is handled in PathManager.cs (INPROGRESS)
	Attacking is handled in AttackManager.cs (TODO)
	Decision making will be handled in DecisionManager.cs (TODO)

	weightedLevel is representative as the SUM of all the normalized combat stats
	healthMul, manaMul, ect. are the mulipliers to denormalize those stats for gameplay.
	These stats are public so spawners can adjust them as required.

	Once stats and behavior are choosen, the AI starts, drawing on the other scripts to carry out actions and
	choices. 
	This will be encapsulated in a decision tree using function pointers.(TODO)
	A decision tree template will be constructed and the pointers will be adjusted depending on the AI type.
	Either the pointers will be directly changed or the function parameters will be adjusted as required.

	Stat based behavior will be decided from the random stats, other stats will be choosen at random.
	
*/
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class AIManager : MonoBehaviour {

	private const int numOfStats = 6;
	private const int minStatValue = 2;
	private const int maxStatValue = 5;

	public int weightedLevel = 30;
	public int healthMul = 1;
	public int manaMul = 1;
	

	void Start () {

		StatCollectionClass s = gameObject.GetComponent<StatCollectionClass> ();

		AIConfig mob = AIBuilder (s, "mob", weightedLevel);
	}

	void Update () {

		//Put it all together here.
	
	}

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/*
		The AIBuilder method creates a config for a AI enabled entity.
		Currently it psuedorandomly assigns stats, eventually options for chosen stats and weighted random stats 
		will be added.
		The AIBuilder will require switch logic to pick a set of nonconflicting behaviors.
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public AIConfig AIBuilder(StatCollectionClass member, string type, int rWeight){
		bool AImade = false;
		bool isMelee = false;
		bool isAggressive = false;		
		bool isStalker = false;		
		bool hasMagic = false;		
		bool isCautious = false;

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/*
			We need to vary the stats based on weight.
			Look at the weight and see if the even split (average) is between the values is over statMax (our maximum 
			normalized stat value).
			If it is, assign randomly from a range between statmin to statMax.
			Otherwise assign randomly statmin to the dividend of weight total with # of stats and add the modulus 
			remainder. This will give stats that fairly equalized to the weight. Let AdjustStats fix any underages or
			overages. 
		*/
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		int[] split = new int[numOfStats];

		if ((rWeight / numOfStats) > maxStatValue) { //Upper bound on stats, might not be needed if things are weighted right.
			int remain = rWeight;
			for (int i = 0; i < numOfStats; i++) {
				split [i] = Random.Range (minStatValue, maxStatValue);
				//For Testing: print ("Random value for stat #" + i.ToString () + " : " + split [i].ToString ());
				remain = remain - split [i];
			}
		} else {
			for (int i = 0; i < numOfStats; i++) {
				split [i] = Random.Range (minStatValue, (rWeight / numOfStats) + rWeight % numOfStats);
				//For Testing: print ("Random value for stat #" + i.ToString () + " : " + split [i].ToString ());
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/*
		 	Sum all the stats together to so we can compare it to weight.
		 	Calculate the expected sum and actual sum diff for our AdjustStats call.
		*/
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		int sumR;
		AdjustStats (split, rWeight);

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/*
			 Finally check that the final sum is correct.
		 	 If the sum is correct set AImade true and carry on!
			 Otherwise throw nasty errors and annoy us.
			 TODO Have this loop back to AdjustStats, error if it fails to properly adjust it again.(We should never
			 hit this second call ideally.)
		*/
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		//Testing
		for(int j = 0; j < numOfStats; j++){
			//print("Final random stats" + split[j].ToString());
		}
		//

		sumR = sumArray (split);
		//print ("The sum is " + sumR.ToString () + " It is supposed to be " + rWeight.ToString ());

		if (sumR == rWeight) {	
			AImade = true;	
		}


		if (AImade) {
			AssignStats(split, member);
		} else {
			Debug.LogError ("AIManager failed to create a proper AIBuild");
		}

		switch(type){
		case "mob":
			if(member.health > 0){
				//Visual adjustments for health thresholds.
			}
			if(member.mana > 0){
				//Visual adjustments for mana thresholds.
				hasMagic = true;
			}
			if(member.strength > 6){
				isMelee = true;
				isAggressive = true;
				//Visual adjustments for being melee.
			}
			if(member.intellect > 6 && member.strength >= member.intellect){
				isCautious = true;
				//Visual adjustments for being cautious.
			}
			if(member.intellect > 6 && member.intellect >= member.strength){
				isStalker = true;
				//Visual adjustments for being a stalker.
			}
			break;
		case "npc":
			break;
		case "boss":
			break;
		default:
			Debug.LogError (type + ": is not a supported type.");
			break;
		}

		AIConfig config = new AIConfig();

		config.isMelee = isMelee;
		config.hasMagic = hasMagic;
		config.isAggressive = isAggressive;
		config.isCautious = isCautious;
		config.isStalker = isStalker;
		config.isMade = AImade;

		print(config.ToString ());

		return config;
	}

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/*
		Function to assign stats from our normalized sum, to their variables in our collection of stats.
		Apply any stat modifiers to de-normalize the values in the array. These will be balance constants.
		IN: int array of finalized stats, a reference to the statcollection being assigned
		OUT: Changes stat collection by reference, no returns.
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	private void AssignStats(int[] split, StatCollectionClass member){

		if (numOfStats < 6) {
			return;
		}

		/// Health
		member.GetComponent<StatCollectionClass>().health = split[0] * healthMul;
		/// Mana
		member.GetComponent<StatCollectionClass>().mana = split [1];
		/// Strength
		member.GetComponent<StatCollectionClass>().strength = split [2];
		/// Intellect
		member.GetComponent<StatCollectionClass>().intellect = split [3];
		/// XP
		member.GetComponent<StatCollectionClass>().xp = split [4];
		/// Level
		member.GetComponent<StatCollectionClass>().playerLevel = split [5];

		print(member.ToString ());
	}

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/*
		Check the random distribution of normalized stats for consistency with the weight that the entity is 
		required to have.
	 	Look at the diff between required sum and actual sum.
	 	If the diff is 0 do nothing.
	 	If the diff is less then zero remove stats randomly until sum is right. Check to make sure random stat is not
	 	already at or below the min.
	 	If the diff is greater than zero, add stats until the sum is right. Check to make sure random stat is not
	 	above or equal to the max.
	 	IN: array of ints, integer weight of the AI
	 	OUT: adjusts the array by reference, no returns.
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	private void AdjustStats(int[] split, int rWeight){

		int sumR = sumArray (split);
		int diff = rWeight - sumR;
		if (diff != 0) {
			if(diff < 0){
				//For testing: print ("We have an abundance of: " + diff.ToString () + " stats.");	
				for (int m = 0; m > diff; m--) {
					sumR = sumArray (split);
					//For testing: print ("The sum is " + sumR.ToString () + " It is supposed to be " + rWeight.ToString ());
					if (sumR == rWeight) {
						break;
					}
					int ranInt = Random.Range (0, numOfStats - 1);
					if(split[ranInt] <= minStatValue){
						m++;
					}
					else{
						split [ranInt] = split [ranInt] - 1;
					}
				}
			}
			else if(diff > 0){
				//For testing: print ("We are missing: " + diff.ToString () + " stats.");
				for (int m = 0; m < diff; m++) {
					sumR = sumArray (split);
					//For testing: print ("The sum is " + sumR.ToString () + " It is supposed to be " + rWeight.ToString ());
					if (sumR == rWeight) {
						break;
					}
					
					int ranInt = Random.Range (0, numOfStats - 1);
					
					if(split[ranInt] > maxStatValue){
						m--;
					}
					else{
						split [ranInt] = split [ranInt] + 1;
					}
				}
			}
		}
	}

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/*
			Helper function to sum the array of normalized stats. I ended up using this code alot so it has been
			refactored.
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	private int sumArray(int[] split){
		int sumR =0;
		for (int k = 0; k < numOfStats; k++) {
			sumR = sumR + split [k];
		}
		return sumR;
	}
}
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/* 
	
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////