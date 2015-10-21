using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCollection : MonoBehaviour {


	Text txt;

	void Start () {
		txt = gameObject.GetComponent<Text>();
	}
	

	void Update () {
		
		//change the value with the CoinNum
		txt.text = "Coins: " + GlobalVariables.CoinNum+"/3";
	}
}
