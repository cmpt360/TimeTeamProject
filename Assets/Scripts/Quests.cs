using UnityEngine;
using System.Collections;

public class Quests : MonoBehaviour {

	//pauses game when looking at quests
	//bool paused = false;
	
	//shows quests
	bool showing = false;
	
	//creating GUI window size / position
	Rect winPos = new Rect (((Screen.width / 2) - 260), ((Screen.height / 2) - 150), 512, 256);
	
	//struct that has all the fields for a quest
	// also has all the getters and settesr for fields
	struct quest
	{
		private string q_name;
		private string info;
		private bool has_quest;
		private bool completed;
		
		//so we're able to set values of structs
		public quest(string n, string i, bool has, bool complete)
		{
			q_name = n;
			info = i;
			has_quest = has;
			completed = complete;
		}
		
		//quest field getters and setters
		public string Name
		{
			get{return q_name;}
			set{q_name = value;}
			
		}
		
		public string Info
		{
			get{return info;}
			set{info = value;}
			
		}
		
		public bool Has
		{
			get{return has_quest;}
			set{has_quest = value;}
			
		}
		
		public bool Complete
		{
			get{return completed;}
			set{completed = value;}
			
		}
	}
	
	//Array for quests
	quest[] QL = new quest[4]; 
	
	//Array for active quests
	quest[] Active = new quest[4];
	
	
	//creating quests
	quest Q1 = new quest ("Q1:\t", "order a frappachino", true, false); 
	quest Q2 = new quest ("Q2:\t", "kill the snake", true, false);         //true for testing
	quest Q3 = new quest ("Q3:\t", "laugh at a bad joke", true, true); 
	quest Q4 = new quest ("Q4:\t", "sing in the shower", true, false);
	
	//putting quests into an array list
	void CreateQuests()
	{
		
		QL [0] = Q1;
		QL [1] = Q2;
		QL [2] = Q3;
		QL [3] = Q4;
		
	}
	
	// Use this for initialization
	void Start () {
		
		CreateQuests ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate ()
	{     
		if (Input.GetButtonDown ("Q")) {
			//if showing hide, else show GUI
			if (showing) {
				showing = false;
				print ("not showing");
			} else {
				showing = true;
				print ("showing");
				//paused = false;
			}
			
		}
	}
	
	void OnGUI ()
	{
		if (showing)
		{
			winPos = GUI.Window(2, winPos, QuestWindow, "Quest Journal");
			
			// works to pause the game but doesn't start again
			//Time.timeScale = 0.0f;
		}
	}
	
	void QuestWindow(int ID)
	{
		GUI.DragWindow (new Rect (0, 10, 1000, 200));
		//GUILayout.Box("Quests: ");
		for (int i =0; i < QL.Length; i++) {
			if ((QL [i].Has) && !QL [i].Complete) {
				GUILayout.Box ((QL [i]).Name + " " + (QL [i]).Info);
			}
		}

	}
}
