using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	private Rigidbody2D rb;
	public int attackDamage = 50;
	public int bulletSpeed = 16;
	public float fireRate = 0.4f;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<HealthManager>().damage(attackDamage);
		}
		Destroy(rb.gameObject);
	}
}