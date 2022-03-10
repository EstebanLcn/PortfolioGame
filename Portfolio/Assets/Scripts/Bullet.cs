using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int dmg = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.name == "Wall" || collider.name == "Enemy" || collider.name == "FinishPoint")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);
        }

       /* Enemy enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDmg(dmg);
            Destroy(gameObject);
        }*/
    }

    public void Update()
    {
        Destroy(GameObject.Find("Bullet(Clone)"), 3);
    }
}
