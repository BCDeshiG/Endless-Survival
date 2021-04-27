using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
	protected Collider2D box; // Item hitbox

	// Start is called before the first frame update
	protected void Start()
	{
		box = GetComponent<Collider2D>();
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