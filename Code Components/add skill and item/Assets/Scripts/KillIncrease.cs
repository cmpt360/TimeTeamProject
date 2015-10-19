using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillIncrease : MonoBehaviour {
    Text txt;
	// Use this for initialization
	void Start () {
        txt = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		// Update text for number of kills
        txt.text = "Kills: " + GlobalVariables.kills;
	}
    
}
