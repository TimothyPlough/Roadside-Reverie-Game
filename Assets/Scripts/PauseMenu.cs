using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool GameIsPause = false;
    public bool GameIsOver = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject GameoverMenu;

    void Start()
    {
        
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape) && !GameIsOver)
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

    public void GameOver()
    {
        Time.timeScale = 0;
        GameIsOver = true;
        GameoverMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

}
