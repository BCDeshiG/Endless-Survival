using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D rb;
	public float moveSpeed = 4f;
	private Vector2 movement;
	private Vector2 mousePos; // Normalised distance from centre
	private float angle = 0; // Player rotation 

	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		mousePos.x = (Input.mousePosition.x / Screen.width) - 0.5f;
		mousePos.y = (Input.mousePosition.y / Screen.height) - 0.5f;
		angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
	}

	// Moves the player
	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}