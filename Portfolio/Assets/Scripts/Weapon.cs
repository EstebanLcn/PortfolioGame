using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public GameObject abilityPrefab;
	public GameObject fireFlash;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	public void Shoot()
	{
		StartCoroutine(ActivationRoutine());
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
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
