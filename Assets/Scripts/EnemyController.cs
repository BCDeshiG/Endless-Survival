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
		// DEBUG Kills enemies in a radius
		if(Input.GetKeyDown(KeyCode.K))
		{
			Vector3 distanceToPlayer =  path.destination - transform.position;
			if(distanceToPlayer.magnitude < 4f)
			{
				hp.damage(100);
			}
		}
	}
}