using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBackground : MonoBehaviour
{
    public List<GameObject> backGround = new List<GameObject>();
    private int backgroundChoice;

    // Start is called before the first frame update
    void Start()
    {
        backgroundChoice = storeValue.value;

        if(backgroundChoice == null)
        {
            backgroundChoice = 999;
        }

        switch (backgroundChoice)
        {
            case 0:
                for(int i = 0; i < backGround.Count; i++)
                {
                    if(i == 0)
                    {
                        backGround[i].SetActive(true);
                    }
                    else
                    {
                        backGround[i].SetActive(false);
                    }
                }
                break;
            case 1:
                for (int i = 0; i < backGround.Count; i++)
                {
                    if (i == 1)
                    {
                        backGround[i].SetActive(true);
                    }
                    else
                    {
                        backGround[i].SetActive(false);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < backGround.Count; i++)
                {
                    if (i == 2)
                    {
                        backGround[i].SetActive(true);
                    }
                    else
                    {
                        backGround[i].SetActive(false);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < backGround.Count; i++)
                {
                    if (i == 3)
                    {
                        backGround[i].SetActive(true);
                    }
                    else
                    {
                        backGround[i].SetActive(false);
                    }
                }
                break;
            default: 
                break;
        }
    }
}
