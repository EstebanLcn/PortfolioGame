using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDialogueBox : MonoBehaviour
{
    public GameObject dialogueBox;
    // Start is called before the first frame update
    public void getBox()
    {
        dialogueBox.SetActive(true);
    }
}
