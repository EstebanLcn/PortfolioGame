using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    public static string currentScene = "";

    public void RestartButton()
    {
        SceneManager.LoadScene(currentScene);
    }
}
