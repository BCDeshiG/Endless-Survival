using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;
	public float moveSpeed = 4f;
	private Vector2 movement;
	private Vector2 mouseDir; // Direction vector to cursor
	private float angle = 0; // Player rotation
	private static int money = 500; // Start player off with $500
	private HealthManager hp; // Store player health
	private SpriteRenderer sprite;
	private Color defColour; // Store default player colour
	// Coroutine for taking damage
	private IEnumerator coroutine;
	private bool invuln = false;
	// Bullet stuff
	public Rigidbody2D bullet;
	private bool firing = false;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		hp = GetComponent<HealthManager>();
		sprite = GetComponentInChildren<SpriteRenderer>();
		defColour = sprite.color;
	}

	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		mouseDir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.position;
		angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
		if(Input.GetButton("Fire"))
		{
			coroutine = fireWeapon();
			StartCoroutine(coroutine);
		}
	}

	// Moves the player and aims
	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
			coroutine = playerDamage(enemy.attackDamage);
			StartCoroutine(coroutine);
		}
	}

	private IEnumerator playerDamage(int damage)
	{
		// Prevents damage during cooldown
		if(!invuln)
		{
			invuln = true;
			hp.damage(damage);
			yield return new WaitForSeconds(0.5f);
			invuln = false;
			sprite.color = defColour;
		}
		else
		{
			sprite.color = Color.red;
		}
	}

	private IEnumerator fireWeapon()
	{
		if(!firing)
		{
			firing = true;
			Rigidbody2D clone = Instantiate(bullet, transform.position, transform.rotation);
			clone.gameObject.SetActive(true);
			int bulletSpeed = clone.gameObject.GetComponent<BulletController>().bulletSpeed;
			float fireRate = clone.gameObject.GetComponent<BulletController>().fireRate;
			clone.velocity = clone.transform.right * bulletSpeed;
			yield return new WaitForSeconds(fireRate);
			firing = false;
		}
	}

	public static int getMoney()
	{
		return money;
	}
	public static void addMoney(int amount)
	{
		money += amount;
	}
}