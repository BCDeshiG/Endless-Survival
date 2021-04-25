using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	private Rigidbody2D rb; // Bullet collision
	public int attackDamage;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// Damages enemy on hit
		if(other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<HealthManager>().damage(attackDamage);
		}
		Destroy(rb.gameObject);
	}
}