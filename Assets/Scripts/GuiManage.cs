using UnityEngine;
using System.Collections;

public class GuiManage : MonoBehaviour {

	GameObject player;
	StatCollectionClass playerStat;
	int maxHealth = 100;
	int maxMana  = 100;

	//var currentStamin : float = 100.0;
	//var maxStamina : int = 100;
	
	float barLength = 0.0f;
	
	//private CharacterJoint chMotor;
	
	void Start()
	{
		player = GameObject.FindWithTag ("Player");
		playerStat = gameObject.GetComponent<StatCollectionClass> ();
		barLength = Screen.width / 8;
		//chMotor = GetComponent(CharacterJoint);
	}
	
	void Update()
	{
		
		//AdjustCurrentHealth(0);
	//	AdjustCurrentMana(0);
		
		if(playerStat.mana >= 0 )
		{
			playerStat.mana += Time.deltaTime * 2.0f;
		}
		
		if(playerStat.mana >= maxMana)
		{
			playerStat.mana = maxMana;
			
		}
		if (playerStat.mana <= 0)
		{
			playerStat.mana=0;
		}
		if(Input.GetKeyDown("f"))
		{
			AdjustCurrentMana(-20);
		}
		
		/*  var controller : CharacterController = GetComponent(CharacterController);

    if(controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
    {
        currentStamin -= Time.deltaTime *14;
        chMotor.movement.maxForwardSpeed = 14;
        chMotor.movement.maxSidewaysSpeed = 14;
        
    }

    else{
        chMotor.movement.maxForwardSpeed = 6;
        chMotor.movement.maxSidewaysSpeed = 6;
    }
    if(controller.velocity.magnitude == 0 && (currentStamin >= 0))
    {
        currentStamin += Time.deltaTime *2;
    }

    if(controller.velocity.magnitude > 0 && Input.GetKey(Getcode.LeftShift) && currentStamin <=0)
    {
        chMotor.movement.maxForwardSpeed = 6;
        chMotor.movement.maxSidewaysSpeed = 6;
    }

    if(currentStamin >= maxStamina)
    {
        currentStamin = maxStamina;
    }
    if(currentStamin <= 0){
        currentStamin = 0;
    }
    */
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(5, 30, 40, 20),"HP");
		GUI.Box(new Rect(5, 50, 40, 20),"Mana");
		// GUI.Box(new Rect(5, 70, 40, 20),"Stam");
		
		
		GUI.Box(new Rect(45,30,barLength,20),playerStat.health.ToString("0")+"/"+maxHealth);
		GUI.Box(new Rect(45,50,barLength,20),playerStat.mana.ToString("0")+"/"+maxMana);
		// GUI.Box(new Rect(45,70,barLength,20),currentStamin.ToString("0")+"/"+maxStamina);
		
	}
	
	
	void AdjustCurrentHealth (int adj)
	{
		playerStat.health += adj;
		if(playerStat.health >= maxHealth)
		{
			playerStat.health = maxHealth;
		}
		if(playerStat.health <= 0)
		{
			playerStat.health=0;
		}
	}
	
	
	
	void AdjustCurrentMana (int adj)
	{
		playerStat.mana += adj;
	}
	

}
