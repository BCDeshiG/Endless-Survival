using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
	protected Collider2D box; // Item hitbox
	protected float aliveTime = 30f; // Time until item disappears
	protected float timeGap = 0; // Time item has existed
	protected HUD hud; // Reference to HUD

	// Start is called before the first frame update
	protected void Start()
	{
		box = GetComponent<Collider2D>();
		hud = GameObject.Find("HUD").GetComponent<HUD>();
	}

	// Despawn item if left uncollected too long
	void FixedUpdate()
	{
		timeGap += Time.fixedDeltaTime;
		if(timeGap > aliveTime)
		{
			Destroy(box.gameObject);
		}
	}

	// Use pickup when touched
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			itemAction(other);
		}
	}

	protected virtual void itemAction(Collider2D other){}
}