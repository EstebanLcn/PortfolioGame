using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicBars : MonoBehaviour
{
    GameObject cinematicBars;

    public static CinematicBars instance;

    private void Start()
    {
        instance = this;
    }

    public void ShowCinematic()
    {
        cinematicBars.SetActive(true);
    }

    public void HideCinematic()
    {
        cinematicBars.SetActive(false);
    }
}
