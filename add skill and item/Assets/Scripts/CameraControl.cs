using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public GameObject follow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Make the camera follow the player
		if (follow != null) {
			this.transform.position = follow.transform.position + new Vector3 (0, 0, -10);
		}
	}
}
