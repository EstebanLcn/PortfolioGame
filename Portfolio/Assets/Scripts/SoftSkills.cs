using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkills : MonoBehaviour
{
    public int health;
    private SpriteRenderer theSr;

    void Start()
    {
        theSr = GetComponent<SpriteRenderer>();
    }
    public void TakeDmg(int dmg)
    {
        StartCoroutine(Wait());
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    private IEnumerator Wait()
    {
        theSr.color = new Color(0f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.05f);
        theSr.color = new Color(1f, 1f, 1f, 1f);
    }
}
