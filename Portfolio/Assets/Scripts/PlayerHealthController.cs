using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth, maxHealth;

    public float invicibleLength;
    private float invicibleCounter;

    private SpriteRenderer theSr;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        theSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invicibleCounter > 0)
        {
            invicibleCounter -= Time.deltaTime;
            if (invicibleCounter <= 0)
            {
                theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, 1);
            }
        }
    }

    public void DealDamage()
    {
        if (invicibleCounter <= 0)
        {
            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
            else
            {
                invicibleCounter = invicibleLength;
                theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, .5f);
            }
            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer()
    {
        if(currentHealth <= 4)
        {
            currentHealth = currentHealth + 2;
            UIController.instance.UpdateHealthDisplay();
        }
        else
        {
            currentHealth = maxHealth;
            UIController.instance.UpdateHealthDisplay();
        }
    }
      
}
