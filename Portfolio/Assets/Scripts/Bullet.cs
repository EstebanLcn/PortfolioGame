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
        if (collider.name == "Wall" || collider.name == "Boss" || collider.gameObject.layer == LayerMask.NameToLayer("SoftSkills"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);
        }
        else if(collider.name == "Player" || collider.name == "Bullet" || collider.name == "ThunderSpell" || collider.name == "Bullet(Clone)" || collider.name == "ThunderSpell(Clone)")
        {
            Destroy(gameObject);
        }
        Boss boss = collider.GetComponent<Boss>();
        if(boss != null)
        {
            boss.TakeDmg(dmg);
            Instantiate(explosion, transform.position, Quaternion.identity);
           // Instantiate(explosionTwo, transform.position, Quaternion.identity);
        }
        SoftSkills softSkills = collider.GetComponent<SoftSkills>();
        if(softSkills != null)
        {
            softSkills.TakeDmg(dmg);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

    public void Update()
    {
        Destroy(GameObject.Find("Bullet(Clone)"), 2f);
    }
}
