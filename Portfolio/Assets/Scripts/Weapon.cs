using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public GameObject abilityPrefab;
	public GameObject fireFlash;
	public float speed = 30f;
	public static Weapon instance;
	public bool canShoot = true;
    private void Start()
    {
		instance = this;
    }
    // Update is called once per frame
    void Update()
	{
		if (Input.GetButtonDown("Fire1") && canShoot)
		{
			Shoot();
		}
	}

	public void Shoot()
	{
		StartCoroutine(ActivationRoutine());
		GameObject bulletClone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * speed;
	}
	private IEnumerator ActivationRoutine()
	{
		yield return new WaitForSeconds(0.1f);
		fireFlash.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		fireFlash.SetActive(false);
	}
	public void ShootAbility1()
    {
		Instantiate(abilityPrefab, firePoint.position, firePoint.rotation);
	}
}
