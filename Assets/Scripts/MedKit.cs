using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherits methods from ItemPickup
public class MedKit : ItemPickup
{
	public int healAmount = 50; // Amount to heal

	// Override method to give health
	protected override void itemAction(Collider2D other)
	{
		// Do negative damage to heal
		other.GetComponent<HealthManager>().damage(-healAmount);
		// Pickup has been used
		Destroy(box.gameObject);
	}
}