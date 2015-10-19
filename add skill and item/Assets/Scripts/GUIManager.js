
var currentHealth : float = 100;
var maxHealth : int = 100;

var currentMana : float = 100.0;
var maxMana : int = 100;

//var currentStamin : float = 100.0;
//var maxStamina : int = 100;

var barLength = 0.0;

private var chMotor : CharacterJoint;

function Start()
{
    barLength = Screen.width / 8;
    chMotor = GetComponent(CharacterJoint);

}

function Update()
{
    
    AdjustCurrentHealth(0);
    AdjustCurrentMana(0);

    if(currentMana >= 0 )
    {
        currentMana += Time.deltaTime * 2;
    }

    if(currentMana >= maxMana)
    {
        currentMana = maxMana;

    }
    if (currentMana <= 0)
    {
        currentMana=0;
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

function OnGUI()
{
    GUI.Box(new Rect(5, 30, 40, 20),"HP");
    GUI.Box(new Rect(5, 50, 40, 20),"Mana");
   // GUI.Box(new Rect(5, 70, 40, 20),"Stam");


    GUI.Box(new Rect(45,30,barLength,20),currentHealth.ToString("0")+"/"+maxHealth);
    GUI.Box(new Rect(45,50,barLength,20),currentMana.ToString("0")+"/"+maxMana);
   // GUI.Box(new Rect(45,70,barLength,20),currentStamin.ToString("0")+"/"+maxStamina);

}


function AdjustCurrentHealth (adj)
    {
        currentHealth += adj;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <= 0)
        {
            currentHealth=0;
        }
    }



    function AdjustCurrentMana (adj)
        {
        currentMana += adj;
        }

