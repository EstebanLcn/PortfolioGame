using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedIncrease : MonoBehaviour
{
    public PlayerMovement2D movement;
    private SpriteRenderer theSr;
    // Start is called before the first frame update
    void Start()
    {
        theSr = GetComponent<SpriteRenderer>();
    }
    public void SpeedPlayer()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        movement.speedMovement = 10;
        theSr.color = new Color(1f, 0.2153054f, 0.1830188f, 1f);       
        yield return new WaitForSeconds(2f);
        theSr.color = new Color(1f, 1f, 1f, 1f);
        movement.speedMovement = 5;
    }
}
