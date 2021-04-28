using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
	public GameObject bullet; // Type of ammunition used
	private Rigidbody2D rb; // Collision of bullet
	private bool firing = false;
	public int attackDamage; // How much damage it inflicts
	public int bulletSpeed; // How fast the bullets travel
	public float fireRate; // Seconds per bullet
	public int startingAmmo; // How many bullets player starts with
	private int ammoCount; // Number of bullets left
	private HUD hud; // Reference to HUD

	void Start()
	{
		rb = bullet.GetComponent<Rigidbody2D>();
		bullet.GetComponent<BulletController>().attackDamage = attackDamage;
		hud = GameObject.Find("HUD").GetComponent<HUD>();
		ammoCount = startingAmmo;
	}

	// Coroutine for firing weapon
	public IEnumerator fireWeapon(Vector2 pos, Quaternion rot)
	{
		if(!firing && !PauseController.isPaused)
		{
			if(ammoCount > 0)
			{
				firing = true;
				// Decrement ammo count
				ammoCount--;
				// Create bullet
				Rigidbody2D clone = Instantiate(rb, pos, rot);
				clone.gameObject.SetActive(true);
				// Fire bullet
				clone.velocity = clone.transform.right * bulletSpeed;
				// Cooldown
				yield return new WaitForSeconds(fireRate);
				firing = false;
			}
			else
			{
				hud.prompt("Out of " + bullet.name + " ammo!");
				yield return new WaitForSeconds(fireRate);
			}
		}
	}

	public void giveAmmo(int amount)
	{
		ammoCount += amount;
	}
	public int getAmmoCount()
	{
		return ammoCount;
	}
}