using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
	private AIPath path;
	private Rigidbody2D rb;
	private HealthManager hp;
	public int attackDamage;
	public int killReward = 100;

	void Start()
	{
		path = GetComponent<AIPath>();
		rb = GetComponent<Rigidbody2D>();
		hp = GetComponent<HealthManager>();
	}

	// Reward the player with money when killed
	void OnDestroy()
	{
		PlayerController.addMoney(killReward);
	}
}