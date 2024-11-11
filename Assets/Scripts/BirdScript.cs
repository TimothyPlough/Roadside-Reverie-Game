using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Vector3 pos;
    public float move_speed;
    public float offset;
    [SerializeField] GameObject bird;
    GameObject pauseScreen;



    // Start is called before the first frame update
    void Start()
    {
        pauseScreen = GameObject.Find("Menus");
    }

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);

        if(!pauseScreen.GetComponent<PauseMenu>().GameIsPause)
            move();

        checkPos();
    }

    private void move()
    {
        if(this.tag == "obstacle")
            transform.position += new Vector3(move_speed, 0, 0);
        else
            transform.position += new Vector3(-1*move_speed,0,0);
    }

    private void checkPos()
    {
        if(this.tag == "obstacle")
        {
            //obstacle bird reaches right side of screen
            if(pos.x > 1.1)
                Destroy(this.gameObject);
        }
        else
        {
            //background bird reaches left side of screen
            if(pos.x < -0.1)
            {
                Instantiate(bird, new Vector3(transform.position.x - offset, transform.position.y, 0), Quaternion.identity);
                Destroy(this.gameObject);
                
            }
        }
    }
}
