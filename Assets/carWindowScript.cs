using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class carWindowScript : MonoBehaviour
{
    public GameObject cam;
    public int initOffset = -3;
    public float timeMax = 20f;
    public float timeMin = 15f;
    public bool reverse = false;

    private float timer;
    private int offsetPos;
    private int offsetNeg;

    private float offset;
    private float offsetOld;
    private float speed; 
    private bool x = true;
    private bool y = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(cam.transform.position.x + initOffset, cam.transform.position.y, cam.GetComponent<CamMove>().zPos);
        timer = Random.Range(timeMin, timeMax);
        if(initOffset > 0)
        {
            offsetNeg = initOffset * -1;
            offsetPos = initOffset;
        }
        else 
        {
            offsetPos = initOffset * -1;
            offsetNeg = initOffset;
        }
        offset = initOffset;
        offsetOld = initOffset;
        speed = cam.GetComponent<CamMove>().camSpeed * 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("time: " + timer);
        Debug.Log("offset: " + offset);

        timer = timer - Time.deltaTime;

        if (timer <= 0)
        {
            if (offset < offsetOld && y == false)
            {
                offsetOld = offsetOld - speed;
                Debug.Log("IS transforming time");
                x = true;
                
            }
            else if (offset > offsetOld && x == false)
            {
                offsetOld = offsetOld + speed;
                Debug.Log("IS transforming time");
                y = true;
            }
            else
            {
                offsetOld = offset;
                offset = Random.Range(offsetNeg, offsetPos);
                timer = Random.Range(timeMin, timeMax);
                x = false;
                y = false;
            }
        }
        transform.position = new Vector3(cam.transform.position.x + offsetOld, transform.position.y, 0);
    }
}
