using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject camEnd;
    public GameObject player;

    public GameObject pauseScreen;   

    public GameObject posYGameObject;
    public GameObject negYGameObject;

    public bool reverse = false;

    public float camSpeed = 0.003f;
    public float camSpeedY = 2f;

    public float offset = 2f;

    public int zPos = -10;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + offset, zPos);

    }

    // Update is called once per frame
    void Update()
    {

        if (camEnd != null && player != null && !pauseScreen.GetComponent<PauseMenu>().GameIsPause && !pauseScreen.GetComponent<PauseMenu>().GameIsOver)
        {
            float playPos = player.transform.position.y; //makes camera match player y

            Vector3 endPos = new Vector3(camEnd.transform.position.x, camEnd.transform.position.y);
            Vector3 playPosY = new Vector3(transform.position.x, playPos + offset, zPos);

            float posYMax = posYGameObject.transform.position.y;
            float negYMax = negYGameObject.transform.position.y;

            if (reverse)
            {
                if (endPos.x < transform.position.x) //change x pos of camera to right
                {
                    transform.position = new Vector3(transform.position.x + (camSpeed*Time.deltaTime), transform.position.y, zPos);
                    if (posYMax < transform.position.y)
                    {
                        if (negYMax < transform.position.y)
                        {
                            transform.position = Vector3.Slerp(transform.position, playPosY, camSpeedY * Time.deltaTime);
                            transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x, this.transform.position.y, zPos), camSpeedY * Time.deltaTime);
                        }
                    }
                }
            }
            else
            {
                if(endPos.x < transform.position.x) //change x pos of camera to left
                {
                    transform.position = new Vector3(transform.position.x - (camSpeed * Time.deltaTime), transform.position.y, zPos);
                    if (posYMax > transform.position.y)
                    {
                        if (negYMax < transform.position.y)
                        {
                            transform.position = Vector3.Slerp(transform.position, playPosY, camSpeedY * Time.deltaTime);
                            transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x, this.transform.position.y, zPos), camSpeedY * Time.deltaTime);
                        }
                        else
                        {
                            transform.position = new Vector3(transform.position.x, negYMax + 0.001f, transform.position.z);
                        }
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, posYMax - 0.001f, transform.position.z);
                    }
                }
            }
        }
    }
}
