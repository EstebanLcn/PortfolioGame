using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneDmg : MonoBehaviour
{
    private SpriteRenderer theSr;

    // Start is called before the first frame update
    void Start()
    {
        theSr = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            PlayerHealthController.instance.isInvincible = true;
            theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, .5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlayerHealthController.instance.isInvincible = false;
            theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, 1);
        }
    }
}
