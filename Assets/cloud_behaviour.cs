using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cloud_behaviour : MonoBehaviour
{
    private bool steppedOn;
    [SerializeField] float disappearenceTimer;
    private float disTime;
    private Animator animator;
    private string currentState;
    const string IDLE = "idle";
    const string DISAPPEAR = "disappear";

    void Start()
    {
        steppedOn = false;                  //keeps track of when the player has jumped off the cloud
        disTime = disappearenceTimer;       //keeps track of the original time
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimationState(IDLE);

        //after player steps off the cloud the timer begins to countdown
        if (steppedOn)
        {
            disappearenceTimer -= Time.deltaTime;
            //play animation?
            ChangeAnimationState(DISAPPEAR);
        }
        //when timer reaches zero the cloud is 'disabled' (able to be used again)
        if (disappearenceTimer <= 0)
            timerEnded();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //tracks when the player has stepped on and off the cloud
        steppedOn = true;
    }

    //disables the cloud
    void timerEnded()
    {
        //play animation?
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Renderer>().enabled = false;
        disappearenceTimer = disTime;
        steppedOn = false;
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);
        currentState = newState;
    }


}
