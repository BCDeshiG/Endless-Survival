using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
	public GameObject bullet; // Type of ammunition used
	private Rigidbody2D rb; // Collision of bullet
	private bool firing = false;
	public int attackDamage;
	public int bulletSpeed;
	public float fireRate;

	void Start()
	{
		rb = bullet.GetComponent<Rigidbody2D>();
		bullet.GetComponent<BulletController>().attackDamage = attackDamage;
	}

	// Coroutine for firing weapon
	public IEnumerator fireWeapon(Vector2 pos, Quaternion rot)
	{
		if(!firing && !PauseController.isPaused)
		{
			firing = true;
			Rigidbody2D clone = Instantiate(rb, pos, rot);
			clone.gameObject.SetActive(true);
			clone.velocity = clone.transform.right * bulletSpeed;
			yield return new WaitForSeconds(fireRate);
			firing = false;
		}
	}
}