using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedIncrease : MonoBehaviour
{
    public PlayerMovement2D movement;
    // Start is called before the first frame update
    public void SpeedPlayer()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        movement.speedMovement = 10;
        yield return new WaitForSeconds(2f);
        movement.speedMovement = 5;
    }
}
