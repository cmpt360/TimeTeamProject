using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public float timer = 1f;
	public float dTimer = 5f;
	public float dTimerReduce = 0.1f;
	public GameObject[] spawnLocations;
	public GameObject spawnObject;
	public int maxNumGroups;
	private int groupWeight = 30;	// Overall weighting for a group of enemies
	private int minInGroup = 2;		// Minimum number of enemies that can spawn in a group
	private int maxInGroup = 5;		// Maximum number of enemies that can spawn in a group
	private float countdown;
	private int numEnemies;			// This will be determined per group spawned
	private float statPerEnemy;		// This will be determined after the number of enemies for a group is determined
	
	// Use this for initialization
	void Start () {
		maxNumGroups = 3;
		spawnLocations = GameObject.FindGameObjectsWithTag ("Spawn");

		for(int k = 0; k < maxNumGroups; k++)
		{
			// Pick random spawn point
			int j = Random.Range(0, spawnLocations.Length - 1);
			/*if(spawnLocations[j].transform.rotation == 90)
				k--;
			else{*/
				// Determine number of enemies to spawn and assign each a number of stat points
				numEnemies = Random.Range (minInGroup, maxInGroup);
				print (numEnemies);
				statPerEnemy = groupWeight / numEnemies;

				for (int i = 0; i < numEnemies; i++)
				{
					// Spawn enemy
					GameObject enemy = Instantiate(spawnObject) as GameObject;
				
					// Set position to selected spawn point
					enemy.transform.position = new Vector3(spawnLocations[j].transform.position.x, spawnLocations[j].transform.position.y, 0f);
				}

		}

		// Initial timer
		countdown = timer + dTimer;
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;

		if (countdown <= 0f) {
			// Determine number of enemies to spawn and assign each a number of stat points
			/*numEnemies = Random.Range (minInGroup, maxInGroup);
			print (numEnemies);
			statPerEnemy = groupWeight / numEnemies;

			for(int k = 0; k <= maxNumGroups; k++)
			{
				// Pick random spawn point
				int j = Random.Range(0, spawnLocations.Length);

				for (int i = 0; i <= numEnemies; i++)
				{
					// Spawn enemy
					GameObject enemy = Instantiate(spawnObject) as GameObject;

					// Set position to selected spawn point
					enemy.transform.position = new Vector3(spawnLocations[j].transform.position.x, spawnLocations[j].transform.position.y, 0f);
				}
			}*/

			// Will logarithmically decrease the time between enemy spawns to a minimum of timer seconds apart
			countdown = timer - Mathf.Min (0f, 0.5f * dTimer * Mathf.Log10(Mathf.Max (1f, Time.timeSinceLevelLoad) * dTimerReduce) - dTimer);
		}
	}
}
