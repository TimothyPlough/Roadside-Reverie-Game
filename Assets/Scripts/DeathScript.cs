using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            //SceneManager.LoadScene("MenuScene");
            pauseMenu.GetComponent<PauseMenu>().GameOver();
            Debug.Log("DEAD");
        }
    }
}
