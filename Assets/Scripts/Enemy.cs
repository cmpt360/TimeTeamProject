﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	StatCollectionClass playerStat;
	StatCollectionClass enemyStat;

	private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D> ();
		enemyStat = gameObject.GetComponent<StatCollectionClass> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Enemy will follow the player
//		if (target != null) {
//			float angl = Mathf.Atan2 (target.transform.position.y - this.transform.position.y, target.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
//			rBody.MoveRotation (angl);
//			CustomFunctions.SetVel (rBody, 0.5f);
//		}
	}

}
