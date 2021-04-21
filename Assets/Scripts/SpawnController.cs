using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
	private GameObject[] enemyTypes; // Store what enemies can spawn here
	private Collider2D region; // Spawn region
	private float timeGap = 0; // How long since last spawn
	public const float spawnInterval = 1; // Wait time between spawns
	
	// Start is called before the first frame update
	void Start()
	{
		enemyTypes = GameObject.FindGameObjectsWithTag("Enemy");
		// Preserve the original so it can be used to spawn more
		foreach (GameObject enemy in enemyTypes)
		{
			enemy.SetActive(false);
		}
		region = GetComponentInChildren<Collider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		timeGap += Time.deltaTime;
		// Choose random point inside region
		float xPos = Random.Range(region.bounds.min.x, region.bounds.max.x);
		float yPos = Random.Range(region.bounds.min.y, region.bounds.max.y);
		Vector3 pos = new Vector3(xPos, yPos, 0);
		// Check if waited long enough
		if(timeGap > spawnInterval)
		{
			// Choose random enemy type
			GameObject enemy = enemyTypes[Random.Range(0, enemyTypes.Length)];
			// Spawn enemy within region
			GameObject newEnemy = Instantiate(enemy, pos, Quaternion.identity); // FIXME Wall spawns
			// Breathe life into newly spawned enemy
			newEnemy.SetActive(true);
			newEnemy.GetComponent<Rigidbody2D>().simulated = true;
			// Reset wait
			timeGap = 0;
		}
	}
}