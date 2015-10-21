using UnityEngine;
using System.Collections;


public struct AIConfig {

	private int test;
	private bool isMade;


	public int something{
		get{return test;}
		set{test = value;}
	}
}

public class AIManager : MonoBehaviour {

	private const int numOfStats = 6;
	private const int minStatValue = 2;
	private const int maxStatValue = 5;

	public int weightedLevel = 30;
	public int healthMul = 1;
	
	// Use this for initialization
	void Start () {
		StatCollectionClass s = gameObject.GetComponent<StatCollectionClass> ();

		AIConfig mob = AIBuilder (s, "mob", weightedLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public AIConfig AIBuilder(StatCollectionClass member, string type, int rWeight){
		bool AImade = false;

		AIConfig config = new AIConfig();
		/*
		 * TODO PICK AN AI TYPE
		switch(type){
		case "player":
		case "mob":
		case "npc":
		default:
			break;
		}
		*/

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// We need to vary the stats based on weight.
		// Look at the weight and see if the even split between the values is over statMax.
		// If it is, assign randomly from statmin to statMax.
		// Otherwise assign randomly statmin to the dividend of weight total with # of stats and add the modulus 
		// remainder.
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		int[] split = new int[numOfStats];

		if ((rWeight / numOfStats) > maxStatValue) {
			int remain = rWeight;
			for (int i = 0; i < numOfStats; i++) {
				split [i] = Random.Range (minStatValue, maxStatValue);
				//print ("Random value for stat #" + i.ToString () + " : " + split [i].ToString ());
				remain = remain - split [i];
			}
		} else {
			for (int i = 0; i < numOfStats; i++) {
				split [i] = Random.Range (minStatValue, (rWeight / numOfStats) + rWeight % numOfStats);
				//print ("Random value for stat #" + i.ToString () + " : " + split [i].ToString ());
			}
		}
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Sum all the stats together to so we can compare it to weight.
		// Calculate the expected sum and actual sum diff.
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		int sumR;

		AdjustStats (split, rWeight);

		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Finally check that the sum is correct.
		// If the sum is correct set AImade true and carry on!
		// Otherwise throw nasty errors and annoy us.
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		for(int j = 0; j < numOfStats; j++){
			//print("Final random stats" + split[j].ToString());
		}

		sumR = sumArray (split);
		//print ("The sum is " + sumR.ToString () + " It is supposed to be " + rWeight.ToString ());

		if (sumR == rWeight) {	
			AImade = true;	
		}

		if (AImade) {
			AssignStats(split, member);
			return config;
		} else {
			Debug.LogError ("AIManager failed to create a proper AIBuild");
			return config;
		}
	}

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
	
	private void AdjustStats(int[] split, int rWeight){
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Now check the random distribution for consistency with the weight it is required to have.
		// Look at the diff between required sum and actual sum.
		// If the diff is 0 do nothing.
		// If the diff is less then zero remove stats randomly until sum is right. Check to make sure random stat is not
		// already at or below the min.
		// If the diff is greater than zero, add stats until the sum is right. Check to make sure random stat is not
		// above or equal to the max.
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		int sumR = sumArray (split);
		int diff = rWeight - sumR;
		if (diff != 0) {
			if(diff < 0){
				//print ("We have an abundance of: " + diff.ToString () + " stats.");	
				for (int m = 0; m > diff; m--) {
					sumR = sumArray (split);
					//print ("The sum is " + sumR.ToString () + " It is supposed to be " + rWeight.ToString ());
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
				//print ("We are missing: " + diff.ToString () + " stats.");
				for (int m = 0; m < diff; m++) {
					sumR = sumArray (split);
					//print ("The sum is " + sumR.ToString () + " It is supposed to be " + rWeight.ToString ());
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
	private int sumArray(int[] split){
		int sumR =0;
		for (int k = 0; k < numOfStats; k++) {
			sumR = sumR + split [k];
		}
		return sumR;
	}
}
