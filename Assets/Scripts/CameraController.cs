using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform player; // Store player position

	// Follows player after they move
	void LateUpdate()
	{
		// Player's 2D position with camera's height
		Vector3 cameraPos = new Vector3(player.position.x, player.position.y, transform.position.z);
		transform.position = cameraPos;
	}
}