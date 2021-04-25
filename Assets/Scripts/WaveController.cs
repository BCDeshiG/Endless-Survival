using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
	private static int roundNum = 1; // Current Wave
	private static int spawnCount = 10; // Number of enemies to spawn
	private static int aliveCount; // Number of living enemies
	private HUD hud; // Reference to HUD
	private float timeGap = 0;
	private bool ending = false;

	// Start is called before the first frame update
	void Start()
	{
		hud = GameObject.Find("HUD").GetComponent<HUD>();
		aliveCount = spawnCount;
	}

	// Update is called once per frame
	void Update()
	{
		timeGap += Time.deltaTime;
		// Advance to next round when all enemies are dead
		if(aliveCount < 1)
		{
			nextWave();
		}
	}

	// Trigger next wave
	public void nextWave()
	{
		if(!ending)
		{
			timeGap = 0;
			ending = true;
			roundNum++;
		}
		else if (timeGap < 5f) // 5 second grace period before next round
		{
			hud.prompt("Wave " + (roundNum-1) + " Complete!", 4f);
		}
		else // Begin next round
		{
			hud.prompt("Wave " + roundNum + " starting!", 4f);
			spawnCount = 10 + (int)(roundNum/2); // Increment enemy count every other round
			aliveCount = spawnCount;
			ending = false;
		}
	}

	// Decrement enemy spawn counter
	public static void decSpawnCount()
	{
		spawnCount--;
	}
	// Decrement living enemy counter
	public static void decAliveCount()
	{
		aliveCount--;
	}
	// Returns number of enemies that need to be spawned
	public static int getSpawnCount()
	{
		return spawnCount;
	}
	// Returns current round number
	public static int getRound()
	{
		return roundNum;
	}
}