using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	public int cost = 0; // Cost to open, default to free
	private bool interacting = false; // Check if interacting with door
	private HUD hud; // Reference to HUD
	public GameObject spawner; // Triggered when door opened
	public AudioClip sound; // Door open sound

	// Finds HUD object and gets reference to it
	void Start()
	{
		interacting = false;
		hud = GameObject.Find("HUD").GetComponent<HUD>();
		spawner.SetActive(false); // Disable spawner since not accessible yet
	}

	// Open door if touching player, pressing E and has enough money
	void OnCollisionStay2D(Collision2D other)
	{
		// Check if actually touching player
		if(other.gameObject.tag == "Player" && interacting)
		{
			if(cost <= PlayerController.getMoney())
			{
				PlayerController.addMoney(-cost);
				hud.prompt("Bought Door for $" + cost);
        		AudioSource.PlayClipAtPoint(sound, transform.position);
				gameObject.SetActive(false); // Door no longer needs to exist
				spawner.SetActive(true); // Enable spawner
			}
			else
			{
				// Tell player they don't have enough money
				hud.prompt("Not enough cash");
			}
		}
	}

	// On-screen prompt to buy door
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			hud.prompt("Press E to unlock for $" + cost);
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