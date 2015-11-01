using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Show : MonoBehaviour {

	// now have 3 GUI 
	public GameObject Object;

	public GameObject Other1;

	public GameObject Other2;

	//set inputkey
	public string InputKey;

	// use to check if the GUI is actived
	private bool showing;
	


	void Update ()
	{     
		//  check if the GUI is actived
		showing = Object.activeInHierarchy;
		//if the key is pressed and the GUI is showing, hide it
		// else show the GUI
		if (Input.GetButtonDown (InputKey)) {
			//set showing to true if false, if false turn it to true
			showing = !showing;

			Object.SetActive(showing);

			//if other GUI actived turn it off
			if(Other1.activeInHierarchy)
			{
				Other1.SetActive(false);

			}

			if(Other2.activeInHierarchy)
			{
				Other2.SetActive(false);
			}



			
		}
	}
}
