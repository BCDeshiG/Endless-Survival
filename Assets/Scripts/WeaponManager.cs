using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	public WeaponController currentWeapon; // Weapon the player is using
	public List<WeaponController> inventory; // List of available weapons
	public int currentIndex = 0; // Index of current weapon in inventory
	private IEnumerator coroutine;
	private Rigidbody2D rb; // Player's rigidbody

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		// Enable weapon use
		currentWeapon.gameObject.SetActive(true);
		// Create inventory
		inventory = new List<WeaponController>();
		// Add starting weapon to inventory
		inventory.Add(currentWeapon);
	}

	// Update is called once per frame
	void Update()
	{
		currentWeapon = inventory[currentIndex];
		if(Input.GetButton("Fire"))
		{
			coroutine = currentWeapon.fireWeapon(rb.position, transform.rotation);
			StartCoroutine(coroutine);
		}
		if(Input.GetButtonDown("Submit"))
		{
			currentIndex++;
			if(currentIndex>=inventory.Count)
			{
				currentIndex = 0;
			}
		}
	}
}