using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherits methods from ItemPickup
public class SpeedShoes : ItemPickup
{
    public float speedTime = 10f; // Duration of speed up
    private IEnumerator coroutine;
    // Attached components
    public SpriteRenderer sprite;
    public GameObject halo;

	// Override method to double player speed
	protected override void itemAction(Collider2D other)
	{
        // Check if already affected
        if(!PlayerController.speeding)
        {
            PlayerController.speeding = true;
            // Hide item
            box.enabled = false;
            sprite.enabled = false;
            halo.SetActive(false);
            hud.prompt("Got Speed Shoes!");
            // Coroutine for applying speed boost
            coroutine = applySpeed(other);
            StartCoroutine(coroutine);
        }
	}

    private IEnumerator applySpeed(Collider2D other)
    {
        // Speed up player for set duration
        other.GetComponent<PlayerController>().moveSpeed *=2;
        yield return new WaitForSeconds(speedTime);
        // Revert to normal movement
        other.GetComponent<PlayerController>().moveSpeed /= 2;
        hud.prompt("Effect has worn off!");
        PlayerController.speeding = false;
        // Item has been used
        Destroy(box.gameObject);
    }

    // Despawn item if left uncollected too long
	void FixedUpdate()
	{
		timeGap += Time.fixedDeltaTime;
		if(timeGap > aliveTime && !PlayerController.speeding)
		{
			Destroy(box.gameObject);
		}
	}
}