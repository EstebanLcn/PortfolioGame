using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerWord : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
            PlayerHealthController.instance.DealDamage();
        }
    }
}
