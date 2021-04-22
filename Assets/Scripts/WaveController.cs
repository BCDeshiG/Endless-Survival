using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
	private int roundNum = 1; // Current Wave
	private static int spawnCount = 24; // Number of enemies to spawn
	private static int aliveCount; // Number of living enemies
	private HUD hud; // Reference to HUD
	private float timeGap = 0;

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
		if(aliveCount < 1)
		{
			nextWave();
		}
	}

	// Trigger next wave
	public void nextWave()
	{
		timeGap = 0; // FIXME Timer
		hud.prompt("Wave " + roundNum + " Complete!", 3f);
		roundNum++;
		hud.prompt("Wave " + roundNum + " starting!");
		spawnCount = 24;
		aliveCount = spawnCount;
	}

	// Decrement enemy counter
	public static void decSpawnCount()
	{
		spawnCount--;
	}
	// Decrement enemy counter
	public static void decAliveCount()
	{
		aliveCount--;
	}
	public static int getSpawnCount()
	{
		return spawnCount;
	}
}