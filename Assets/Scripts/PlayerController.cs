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
	private IEnumerator coroutine;
	private bool invuln = false;
	// Weapon stuff
	public WeaponController weapon;

	// Get pointers to components
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		hp = GetComponent<HealthManager>();
		sprite = GetComponentInChildren<SpriteRenderer>();
		// Remember what colour player started as
		defColour = sprite.color;
		// Enable weapon use
		weapon.gameObject.SetActive(true);
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
			coroutine = weapon.fireWeapon(rb.position, transform.rotation);
			StartCoroutine(coroutine);
		}
	}

	// Moves the player and aims
	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	// Take damage upon touching enemy
	void OnCollisionStay2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
			coroutine = playerDamage(enemy.attackDamage);
			StartCoroutine(coroutine);
		}
	}

	// Coroutine for taking damage
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

	public static int getMoney()
	{
		return money;
	}
	public static void addMoney(int amount)
	{
		money += amount;
	}
}