using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public float timer = 1f;
	public float dTimer = 5f;
	public float dTimerReduce = 0.1f;
	public GameObject[] spawnLocations;
	public GameObject spawnObject;
	private float countdown;

	// Use this for initialization
	void Start () {

		spawnLocations = GameObject.FindGameObjectsWithTag ("Spawn");

		// Initial timer
		countdown = timer + dTimer;
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;

		if (countdown <= 0f) {

			// Spawn enemy
			GameObject enemy = Instantiate(spawnObject) as GameObject;

			// Pick random spawn point
			int i = Random.Range(0, spawnLocations.Length);

			// Set position to selected spawn point
			enemy.transform.position = new Vector3(spawnLocations[i].transform.position.x, spawnLocations[i].transform.position.y, 0f);

			// Will logarithmically decrease the time between enemy spawns to a minimum of timer seconds apart
			countdown = timer - Mathf.Min (0f, 0.5f * dTimer * Mathf.Log10(Mathf.Max (1f, Time.timeSinceLevelLoad) * dTimerReduce) - dTimer);
		}
	}
}
