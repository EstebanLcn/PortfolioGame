using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth, maxHealth;

    public float invicibleLength;
    private float invicibleCounter;
    public bool isInvincible = false;
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
        if (!isInvincible)
        {
            if (invicibleCounter <= 0)
            {
                currentHealth -= 1;

                if (currentHealth <= 0)
                {
                   Die();
                }
                else
                {
                    invicibleCounter = invicibleLength;
                    theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, .5f);
                }
                UIController.instance.UpdateHealthDisplay();
            }
        }
    }

    public void HealPlayer()
    {
        if(currentHealth <= 4)
        {
            StartCoroutine(HealColor());
            currentHealth = currentHealth + 2;
            UIController.instance.UpdateHealthDisplay();
        }
        else
        {
            StartCoroutine(HealColor());
            currentHealth = maxHealth;
            UIController.instance.UpdateHealthDisplay();
        }
    }
    private IEnumerator HealColor()
    {
        theSr.color = new Color(0.02662864f, 0.8301887f, 0.1225607f, 1f);
        yield return new WaitForSeconds(1f);
        theSr.color = new Color(1f, 1f, 1f, 1f);
    }

    public void InviciblePlayer()
    {
        isInvincible = true;
    }
    public void Die()
    {
        currentHealth = 0;
        gameObject.SetActive(false);
        UIController.instance.UpdateHealthDisplay();
        SceneManager.LoadScene("GameOverScene");
        GameOverScreen.currentScene = SceneManager.GetActiveScene().name;
    }
    public void Disappear()
    {
        currentHealth = 0;
        gameObject.SetActive(false);
    }
}
      

