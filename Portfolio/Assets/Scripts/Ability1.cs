using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1 : MonoBehaviour
{
    public GameObject hitEffect;
    public float speed = 20f;
    public Rigidbody2D rb;
    public int dmg = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
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
}
