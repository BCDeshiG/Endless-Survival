using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherits methods from ItemPickup
public class MedKit : ItemPickup
{
	public int healAmount = 20; // Amount to heal

	// Override method to give health
	protected override void itemAction(Collider2D other)
	{
		// Check if player already at full health
		HealthManager playerHP = other.GetComponent<HealthManager>();
		if(playerHP.getHealth()<100)
		{
			// Do negative damage to heal
			playerHP.heal(healAmount);
			hud.prompt("Healed " + healAmount + " HP!");
			// Pickup has been used
			Destroy(box.gameObject);
		}
	}
}