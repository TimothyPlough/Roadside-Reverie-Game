using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelct : MonoBehaviour
{

    public void playDay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void playNight()
    {
        //load night scene
        //SceneManager.LoadScene("night");
        Debug.Log("Night selected");
    }

}
