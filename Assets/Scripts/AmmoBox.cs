using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherits methods from ItemPickup
public class AmmoBox : ItemPickup
{
	public int ammoAmount = 50; // Amount of ammo to give
	public GameObject ammoType; // Type of ammo

	// Override method to give health
	protected override void itemAction(Collider2D other)
	{
		// Get current weapon
		WeaponController weapon = other.GetComponent<WeaponManager>().currentWeapon;
		// Check if ammo type matches the weapon
		if(weapon.bullet == ammoType)
		{
			// Give that weapon ammo
			weapon.giveAmmo(ammoAmount);
			hud.prompt("Got " + ammoAmount + " bullets! (" + ammoType.name + ")");
			// Pickup has been used
			Destroy(box.gameObject);
		}
	}
}