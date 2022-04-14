using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1 : MonoBehaviour
{
    public GameObject hitEffect;
    public float speed = 20f;
    public Rigidbody2D rb;
    public int dmg = 12;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.name == "Wall" || collider.name == "Boss" || collider.gameObject.layer == LayerMask.NameToLayer("SoftSkills") || collider.gameObject.layer == LayerMask.NameToLayer("WordFall"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);
        }
        Boss boss = collider.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDmg(dmg);
        }

        SoftSkills softSkills = collider.GetComponent<SoftSkills>();
        if (softSkills != null)
        {
            softSkills.TakeDmg(dmg);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "BossLast")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);
        }
        BossLast bossLast = collision.GetComponent<BossLast>();
        if (bossLast != null)
        {
            bossLast.TakeDmg(dmg);
        }
    }
}
