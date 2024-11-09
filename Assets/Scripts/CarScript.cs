using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    //offset is used to ensure the car is slower/faster than the camera
    [SerializeField] float speed_offset;
    [SerializeField] float speed_max;
    [SerializeField] float speed_min;

    private float speed;
    void Start()
    {
        //determine if the car is 'slow' or 'fast'
        int t = Random.Range(1, 2);

        //faster than player/car  
        if (t == 1)
        {
            //speed = Random.Range(0 + speed_offset, speed_max);
            speed = speed_max;
        }
        

        //slower than player/car
        else
        {
            //speed = Random.Range(speed_min, 0 - speed_offset);
            speed = speed_min;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);
    }
}
