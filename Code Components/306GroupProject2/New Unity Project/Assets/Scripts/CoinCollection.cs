using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCollection : MonoBehaviour {

	Text txt;

	void Start () {
		txt = gameObject.GetComponent<Text>();
	}
	

	void Update () {
		

		txt.text = "Coins: " + GlobalVariables.CoinNum+"/3";
	}
}
