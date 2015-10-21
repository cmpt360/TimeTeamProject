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
	void Update () 
	{
		// Movement controls use arrow keys
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate (Vector3.down * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate (Vector3.right * speed * Time.deltaTime);
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
