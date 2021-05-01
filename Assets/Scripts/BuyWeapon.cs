using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeapon : MonoBehaviour
{
	private Collider2D region; // Area you can buy weapon
	public WeaponController weapon; // Weapon you buy here
	private WeaponManager wm; // Player's weapons
	public int cost; // How much money is required
	private bool interacting = false; // Check if interacting with area
	private bool buying = false; // Check if currently buying weapon
	private HUD hud; // Reference to HUD
	private IEnumerator coroutine;

	// Start is called before the first frame update
	void Start()
	{
		interacting = false;
		buying = false;
		region = GetComponent<Collider2D>();
		hud = GameObject.Find("HUD").GetComponent<HUD>();
		wm = GameObject.Find("Player").GetComponent<WeaponManager>();
	}

	// Buy weapon if touching player, pressing E and has enough money
	void OnTriggerStay2D(Collider2D other)
	{
		// Check if actually touching player
		if(other.gameObject.tag == "Player" && interacting)
		{
			coroutine = buyAction(other);
			StartCoroutine(coroutine);
		}
	}

	// On-screen prompt to buy weapon
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			hud.prompt("Press E to buy " + weapon.name + " for $" + cost, 2f);
		}
	}

	// Coroutine for buying weapon
	private IEnumerator buyAction(Collider2D other)
	{
		if(!buying)
		{
			buying = true;
			if(cost <= PlayerController.getMoney())
			{
				// Take money from player
				PlayerController.addMoney(-cost);
				hud.prompt("Bought " + weapon.name + " for $" + cost);
				// Check if player is buying ammo
				if(wm.inventory.Contains(weapon))
				{
					// Refill ammo and switch weapon
					weapon.giveAmmo(weapon.startingAmmo);
					wm.currentWeapon.gameObject.SetActive(false);
					wm.currentIndex = wm.inventory.IndexOf(weapon);
					weapon.gameObject.SetActive(true);
				}
				else
				{
					// Replace weapon
					wm.currentWeapon.gameObject.SetActive(false);
					wm.inventory.Add(weapon);
					AudioSource.PlayClipAtPoint(weapon.reloadSound, transform.position);
					wm.currentIndex = wm.inventory.Count - 1;
					weapon.gameObject.SetActive(true);
				}
			}
			else
			{
				// Tell player they don't have enough money
				hud.prompt("Not enough cash");
			}
			yield return new WaitForSeconds(0.5f);
			buying = false;
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