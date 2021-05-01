using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	public int baseHealth = 100; // Starting health
	private int health = 100; // Current health
	private Rigidbody2D mob; // Store entity collision
	public AudioClip damageSound; // Sound played when hurt
	public AudioClip healSound; // Sound played when healed

	void Start()
	{
		// Initialise health
		health = baseHealth;
		// Gets the pointer
		mob = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		// Entity death
		if (health <= 0)
		{
			// Ensure health isn't negative
			health = 0;
			// Halt entity movement
			mob.simulated = false;
			// Enemy death
			if(mob.gameObject.tag != "Player")
			{
				// Despawn enemy
				Destroy(mob.gameObject);
				WaveController.decAliveCount();
			}
			else // Player death
			{
				// Hide player
				mob.gameObject.SetActive(false);
			}
		}
		// Limit health to 100%
		if (health > baseHealth)
		{
			health = baseHealth;
		}
	}

	// Decreases entity health
	public void damage(int amount)
	{
		health -= amount;
		// Play sound when losing health
		if(amount > 0)
		{
			AudioSource.PlayClipAtPoint(damageSound, transform.position);
		}
		else
		{
			AudioSource.PlayClipAtPoint(healSound, transform.position);
		}
	}

	// Returns current health
	public int getHealth()
	{
		return health;
	}
}