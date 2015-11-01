using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//public Transform spawnPoint;
	Rigidbody2D rBody;
	SpriteRenderer sRender;
	StatCollectionClass playerStat;

	//private Animator anim;

	public int xp;

	public float speed = 8f;
	public GameObject projectile;
	public float shotRecharge = 1f;
	public float shotSpeed = 8f;
	private float shotTimer = 0f;
	
	// Use this for initialization
	void Start () 
	{
		rBody = GetComponent<Rigidbody2D> ();
		playerStat = gameObject.GetComponent<StatCollectionClass> ();
		playerStat.health = 100;
		playerStat.mana = 100;
		playerStat.intellect = 1;
	}
	
	// Update is called once per frame
	// Add face direction code
	// FIXME
	// Player should not be able to move at an angle.
	// Player should have smooth turning. (Animations and/or blend?)
	void Update () 
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			//since change the face direction all move should be face direction(just x)
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			//change the rotation z to 90(face up)
			transform.rotation = Quaternion.Euler(0,0,90);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			//change the rotation z to -90(face down)
			transform.rotation = Quaternion.Euler(0,0,-90);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			//change the rotation z to 90(face left)
			transform.rotation = Quaternion.Euler(0,0,180);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			//change the rotation z to 90(face right)
			transform.rotation = Quaternion.Euler(0,0,0);
		}
		
		// Add a delay between shots
		if (shotTimer > 0f)
		{
			shotTimer -= Time.deltaTime;
		}
		
		// Pick the direction to fire the shot based on the character's rotation
		Vector2 dirVector = new Vector2 (Mathf.Cos (rBody.rotation * Mathf.Deg2Rad), Mathf.Sin (rBody.rotation * Mathf.Deg2Rad));

		// If player firing and timer not on cooldown
		if (Input.GetButton("Fire1") & shotTimer <= 0f) 
		{
			shotTimer = shotRecharge;

			// Creates projectile 1f unit in front of the center of the player
			GameObject shot = Instantiate(projectile, this.transform.position + (new Vector3(dirVector.x, dirVector.y, 0f) * 1f), this.transform.rotation) as GameObject;
			Rigidbody2D shotRBody = shot.GetComponent<Rigidbody2D>();

			// Set projectile's velocity
			if (shotRBody != null)
			{
				shotRBody.velocity = dirVector * shotSpeed;
			}

		}     
	}

	
	void OnCollisionEnter2D(Collision2D collision)
	{
		// If player collides with an enemy they take damage
		if (collision.gameObject.tag == "Enemy") {
			StatCollectionClass enemyStat  = collision.gameObject.GetComponent<StatCollectionClass> ();
			playerStat.health = playerStat.health - enemyStat.intellect;
		}
		// If player is at 0 health, reset the scene
		if(playerStat.health <= 0)
		{
			Reset ();
		}
	}
	
	// Restart level
	void Reset(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
