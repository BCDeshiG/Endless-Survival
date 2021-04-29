using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLook : MonoBehaviour
{
	public Transform target; // Object eye looks at

	// Update is called once per frame
	void Update()
	{
		// Get direction to target
		Vector3 dir = target.position - transform.position;
		// Move eye towards target
		transform.localPosition = dir.normalized * 0.064f;
	}
}