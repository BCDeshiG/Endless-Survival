using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	public int cost = 0; // Cost to open, default to free
	private bool interacting = false; // Check if interacting with door

	// Open door if touching player, pressing E and has enough money
	void OnCollisionStay2D(Collision2D other)
	{
		// Check if actually touching player
		if(other.gameObject.tag == "Player" && interacting)
		{
			if(cost <= PlayerController.getMoney())
			{
				PlayerController.addMoney(cost * -1);
				Debug.Log("Bought Door for $" + cost.ToString());
				gameObject.SetActive(false); // Door no longer needs to exist
			}
			else
			{
				// Tell player they don't have enough money
				Debug.Log("Not enough cash"); // FIXME spams log
			}
		}
	}

	// On-screen prompt to buy door
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Debug.Log("Press E to unlock for $" + cost.ToString());
		}
	}

	// Check if player is pressing the interact key
	void Update()
	{
		if(Input.GetButton("Interact"))
		{
			interacting = true;
		}
		else
		{
			interacting = false;
		}
	}
}