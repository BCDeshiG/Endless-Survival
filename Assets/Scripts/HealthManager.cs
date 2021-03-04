using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	public static int health = 100;
	// Store player collision
	public Rigidbody2D player;

	// Update is called once per frame
	void Update()
	{
		// Player death
		if (health <= 0)
		{
			// Ensure health isn't negative
			health = 0;
			Debug.Log("You Died!"); // FIXME should probably start HUD
			// Halt player movement
			player.simulated = false;
		}
	}

	// Decreases player health
	public static void damage(int amount)
	{
		health -= amount;
	}

	// Increases player health
	public static void heal(int amount)
	{
		health += amount;
	}
}