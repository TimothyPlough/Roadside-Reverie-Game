using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
