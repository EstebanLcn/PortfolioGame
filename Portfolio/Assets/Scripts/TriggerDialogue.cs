using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject messageBox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        messageBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        messageBox.SetActive(false);
    }
}
