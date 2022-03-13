using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int dmg = 5;
    public GameObject explosion;
    //public GameObject explosionTwo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.name == "Wall" || collider.name == "Boss")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);
        }
        Boss boss = collider.GetComponent<Boss>();
        if(boss != null)
        {
            boss.TakeDmg(dmg);
            Instantiate(explosion, transform.position, Quaternion.identity);
           // Instantiate(explosionTwo, transform.position, Quaternion.identity);
        }
    }

    public void Update()
    {
        Destroy(GameObject.Find("Bullet(Clone)"), 3);
    }
}
