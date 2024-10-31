using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPause = false;

    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
                Resume();
            else
                Pause();
        }

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPause = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPause = true;

    }

    public void LoadMenu()
    {
        //settings menu
        Debug.Log("Loading Menu...");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

}
