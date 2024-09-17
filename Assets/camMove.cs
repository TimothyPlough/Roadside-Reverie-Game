using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour
{
    public GameObject camEnd;
    public GameObject player;
    public bool reverse = false;
    public float camSpeed;
    public float offset = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if (camEnd != null)
        {
            float playPos = player.transform.position.y; //makes camera match player y

            Vector3 endPos = new Vector3(camEnd.transform.position.x, playPos+offset, -10);

            if (reverse)
            {
                if (endPos.x < transform.position.x) //change x pos of camera to right
                {
                    transform.position = Vector3.Slerp(transform.position, endPos, camSpeed * Time.deltaTime);
                }
            }
            else
            {
                if(endPos.x < transform.position.x) //change x pos of camera to left
                {
                    transform.position = Vector3.Slerp(transform.position, endPos, camSpeed * Time.deltaTime);
                }
            }
        }
    }
}
