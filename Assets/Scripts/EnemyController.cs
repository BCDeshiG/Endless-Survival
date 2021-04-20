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

	void Start()
	{
		path = GetComponent<AIPath>();
		rb = GetComponent<Rigidbody2D>();
		hp = GetComponent<HealthManager>();
	}

	// Update is called once per frame
	void Update()
	{
		// DEBUG Kills enemy
		if(Input.GetKeyDown(KeyCode.K))
		{
			hp.damage(100);
		}
	}
}