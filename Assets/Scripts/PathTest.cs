using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathTest : MonoBehaviour
{
	private AIPath path;
	private Rigidbody2D rb;
	private Vector2 movement;
	public float moveSpeed;

	void Start()
	{
		path = GetComponent<AIPath>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		// Head towards player
		Vector2 dirToPlayer = path.desiredVelocity.normalized;
		movement.x = dirToPlayer.x;
		movement.y = dirToPlayer.y;
	}

	// Moves the guard at a constant rate
	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}