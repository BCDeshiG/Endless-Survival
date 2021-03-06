using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	public int baseHealth = 100; // Starting health
	private int health = 100; // Current health
	private Rigidbody2D mob; // Store entity collision

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
		}
	}

	// Decreases entity health
	public void damage(int amount)
	{
		health -= amount;
	}

	// Returns current health
	public int getHealth()
	{
		return health;
	}
}