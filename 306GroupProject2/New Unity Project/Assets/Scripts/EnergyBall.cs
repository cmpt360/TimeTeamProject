using UnityEngine;
using System.Collections;

public class EnergyBall : MonoBehaviour {

	public StatCollectionClass stat;

	public SkillTree2 skill;

	private float fireDelay = 1f;

	float cooldownTimer = 0;
	//AudioSource audio;
	
	//prefab to spawn
	public GameObject EnergyBallPrefab;
	
	//the Ball that has been spawned
	public GameObject spawnedEnergyBall;
	
	
	
	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		cooldownTimer -= Time.deltaTime;


		if(Input.GetKey(KeyCode.Alpha1)&& stat.EnergyBallUnlocked == true && cooldownTimer <=0&& stat.mana>= skill.EnergyBallMpCost){

			stat.mana -= skill.EnergyBallMpCost;

			//audio.Play ();

			spawnedEnergyBall = GameObject.Instantiate(EnergyBallPrefab, transform.position, transform.rotation) as GameObject;

			spawnedEnergyBall.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(500,0));

			cooldownTimer = fireDelay;
			
		}
	}
}
