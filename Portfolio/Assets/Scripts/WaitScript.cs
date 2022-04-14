using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitScript : MonoBehaviour
{

    public void Wait()
    {
        StartCoroutine(WaitFunction());
    }

    IEnumerator WaitFunction()
    {
        yield return new WaitForSeconds(1f);
    }
}
