using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//public Transform spawnPoint;
	Rigidbody2D rBody;
	SpriteRenderer sRender;

	//private Animator anim;


	public float speed = 8f;
	public GameObject projectile;
	public float shotRecharge = 1f;
	public float shotSpeed = 8f;
	private float shotTimer = 0f;
	
	// Use this for initialization
	void Start () 
	{
		rBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
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


		if (shotTimer > 0f)
		{
			shotTimer -= Time.deltaTime;
		}

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
}
