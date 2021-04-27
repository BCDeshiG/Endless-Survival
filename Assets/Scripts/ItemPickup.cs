using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
	protected Collider2D box; // Item hitbox
	protected HUD hud;

	// Start is called before the first frame update
	protected void Start()
	{
		box = GetComponent<Collider2D>();
		hud = GameObject.Find("HUD").GetComponent<HUD>();
	}

	// Heal player when touched
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			itemAction(other);
		}
	}

	protected virtual void itemAction(Collider2D other){}
}