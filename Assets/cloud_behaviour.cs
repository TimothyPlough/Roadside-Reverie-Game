using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cloud_behaviour : MonoBehaviour
{
    private bool steppedOn;
    [SerializeField] float disappearenceTimer;
    private float disTime;
    [SerializeField] Animator anim;

    void Start()
    {
        disTime = disappearenceTimer;       //keeps track of the original time
    }

    // Update is called once per frame
    void Update()
    {
        manageState();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //tracks when the player has stepped on and off the cloud
        steppedOn = true;
    }

    private void manageState()
    {
        //after player steps off the cloud the timer begins to countdown
        if (steppedOn)
        {
            disappearenceTimer -= Time.deltaTime;
            anim.SetBool("disappear", true);
        }
        //when timer reaches zero the cloud is 'disabled' (able to be used again)
        if (disappearenceTimer <= 0)
            timerEnded();
    }

    //disables the cloud
    void timerEnded()
    {
        //play animation?
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Renderer>().enabled = false;
        disappearenceTimer = disTime;
        steppedOn = false;
        anim.SetBool("disappear", false);
    }


}
