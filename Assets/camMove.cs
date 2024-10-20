using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour
{
    public GameObject camEnd;
    public GameObject yMaxPos;
    public GameObject yMaxNeg;
    public GameObject player;
    public bool reverse = false;
    public float camSpeed = 0.003f;
    public float camSpeedY = 0.1f;
    public float offset = 0.5f;
    public int zPos = -10;
    // Update is called once per frame
    void Update()
    {
        if (camEnd != null && yMaxPos != null && yMaxNeg != null && player != null)
        {
            float playPos = player.transform.position.y; //makes camera match player y

            Vector3 endPos = new Vector3(camEnd.transform.position.x, camEnd.transform.position.y);
            Vector3 playPosY = new Vector3(transform.position.x, player.transform.position.y - offset, zPos);

            if (reverse)
            {
                if (endPos.x < transform.position.x) //change x pos of camera to right
                {
                    transform.position = new Vector3(transform.position.x + camSpeed, transform.position.y, zPos);
                    if (transform.position.y < yMaxPos.transform.position.y && transform.position.y > yMaxNeg.transform.position.y)
                    {
                        transform.position = Vector3.Slerp(transform.position, playPosY, camSpeedY * Time.deltaTime);
                    }
                }
            }
            else
            {
                if(endPos.x < transform.position.x) //change x pos of camera to left
                {
                    transform.position = new Vector3(transform.position.x - camSpeed, transform.position.y, zPos);
                    if(transform.position.y < yMaxPos.transform.position.y)
                    { 
                        transform.position = Vector3.Slerp(transform.position, playPosY, camSpeedY * Time.deltaTime);
                    }
                }
            }
        }
    }
}
