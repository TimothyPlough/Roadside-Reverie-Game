using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelct : MonoBehaviour
{

    public void playDay()
    {
        storeValue.value = 0;
        SceneManager.LoadScene("infiniteRunnerScene");
    }

    public void playMidday()
    {
        storeValue.value = 1;
        SceneManager.LoadScene("infiniteRunnerScene");
    }

    public void playEvening()
    {
        storeValue.value = 2;
        SceneManager.LoadScene("infiniteRunnerScene");
    }

    public void playNight()
    {
        storeValue.value = 3;
        SceneManager.LoadScene("infiniteRunnerScene");
    }

}
