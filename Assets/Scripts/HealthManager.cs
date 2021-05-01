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

	public void damage(int amount)
	{
		// Decrease entity health
		health -= amount;
		// Play sound when losing health
		AudioSource.PlayClipAtPoint(damageSound, transform.position);
		// Check if that killed entity
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
				// Mark player as dead
				PlayerController.isDead = true;
			}
		}
	}

	public void heal(int amount)
	{
		// Increase entity health
		health += amount;
		// Play healing sound
		AudioSource.PlayClipAtPoint(healSound, transform.position);
		// Limit health to 100%
		if (health > baseHealth)
		{
			health = baseHealth;
		}
	}

	// Returns current health
	public int getHealth()
	{
		return health;
	}
}