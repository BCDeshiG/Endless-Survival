using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
	private HealthManager hp;
	public int attackDamage; // How much damage is dealt to the player
	public int killReward = 100; // Amount of money given to player when killed
	public GameObject[] itemDrops; // Store what items can be dropped
	public float itemChance = 0.2f; // 20% chance of dropping item

	void Start()
	{
		hp = GetComponent<HealthManager>();
	}

	// Executes when enemy dies
	void OnDestroy()
	{
		// Award player with money
		PlayerController.addMoney(killReward);
		// Chance to spawn item
		if(Random.value <= itemChance && itemChance != 0)
		{
			// Choose random item
			int randInt = Random.Range(0, itemDrops.Length);
			// Spawn item
			GameObject item = Instantiate(itemDrops[randInt], transform.position, Quaternion.identity);
			// Show in world
			item.SetActive(true);
		}
	}
}