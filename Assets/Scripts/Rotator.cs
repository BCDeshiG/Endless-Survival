using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float rotSpeed = 0; // Rotation speed

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(0,0,rotSpeed) * Time.deltaTime);
	}
}