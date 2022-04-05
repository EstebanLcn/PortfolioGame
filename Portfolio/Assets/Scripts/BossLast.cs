using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLast : MonoBehaviour
{
    public int health;
    public Slider healthBar;
    private SpriteRenderer theSr;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        theSr = GameObject.Find("eagle-attack-1").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
    }
    public void TakeDmg(int dmg)
    {
        StartCoroutine(Wait());
        health -= dmg;
        animator.SetInteger("health", health);
        if (health <= 0)
        {
            Die();
            healthBar.value = 0;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    private IEnumerator Wait()
    {
        theSr.color = new Color(1f, 0.2153054f, 0.1830188f, 1f);
        yield return new WaitForSeconds(0.05f);
        theSr.color = new Color(1f, 1f, 1f, 1f);
    }

}
