using UnityEngine;
using System.Collections;

public class EnergyBall : MonoBehaviour {
	//connect with StatCollectionClass
	public StatCollectionClass stat;

	//connect with SkillTree2 class
	public SkillTree2 skill;

	//set a cooldown time for skill
	private float skillDelay = 1f;

	//use to track time
	float cooldownTimer = 0;
	//AudioSource audio later
	
	//prefab to spawn
	public GameObject EnergyBallPrefab;
	
	//the Ball that has been spawned
	public GameObject spawnedEnergyBall;
	
	
	
	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource>(); will do it later
	}
	
	// Update is called once per frame
	void Update () {

		// decrease cooldown with real time
		cooldownTimer -= Time.deltaTime;

		//skill can be shot out when press key 1 and skill is active and cooldown equal 0
		if(Input.GetKey(KeyCode.Alpha1)&& stat.EnergyBallUnlocked == true && cooldownTimer <=0&& stat.mana>= skill.EnergyBallMpCost){

			//decrease the mana by skill mana cost
			stat.mana -= skill.EnergyBallMpCost;

			//audio.Play (); will do it later

			//spawn a energy ball as a object
			spawnedEnergyBall = GameObject.Instantiate(EnergyBallPrefab, transform.position, transform.rotation) as GameObject;
			//add force to energy ball
			spawnedEnergyBall.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(500,0));

			//set cooldown time as the delay we want
			cooldownTimer = skillDelay;
			
		}
	}
}
