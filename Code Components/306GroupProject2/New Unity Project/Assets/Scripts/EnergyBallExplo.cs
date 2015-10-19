using UnityEngine;
using System.Collections;

public class EnergyBallExplo : MonoBehaviour {

	public StatCollectionClass enemyStat;
	GameObject panel;

	SkillTree2 skill;

	
	//AudioSource audio;
	
	void Start () 
	{
		panel = GameObject.FindWithTag ("Panel");

		skill = panel.GetComponent<SkillTree2> ();

		Destroy(gameObject, 3f);
		
	}
	
	
	void OnTriggerEnter2D(Collider2D col)
	{


		if (col.gameObject.tag == "Enemy") {

			enemyStat = col.GetComponent<StatCollectionClass>();

			enemyStat.health-=skill.EnergyBalldamage;
			
			Destroy (gameObject);


		} 
		
		if (col.gameObject.tag == "wallTop"||col.gameObject.tag == "wallBottom"
		    ||col.gameObject.tag == "wallLeft"|| col.gameObject.tag == "wallRight"
		    ||col.gameObject.tag == "Obstacle") {
			
			Destroy (gameObject);

			
		}

	}
}
