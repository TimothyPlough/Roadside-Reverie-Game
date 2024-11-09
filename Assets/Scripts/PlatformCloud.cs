using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformCloud : MonoBehaviour
{
    private bool steppedOn;
    [SerializeField] float disappearenceTimer;
    private float disTime;
    private bool hidden;

    [SerializeField] float returnTimer;
    private float returnTime;

    [SerializeField] Animator anim;

    void Start()
    {
        disTime = disappearenceTimer;       //keeps track of the original time
        returnTime = returnTimer;
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
            anim.SetBool("CloudVanish", true);
        }
        //when timer reaches zero the cloud is 'disabled' (able to be used again)
        if (disappearenceTimer <= 0)
            disappear();

        if(hidden)
        {
            returnTimer -= Time.deltaTime;
        }
        if (returnTimer <= 0)
            reappear();
    }

    //disables the cloud
    private void disappear()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Renderer>().enabled = false;
        disappearenceTimer = disTime;
        steppedOn = false;
        anim.SetBool("CloudVanish", false);
        hidden = true;
    }

    private void reappear()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<Renderer>().enabled = true;
        anim.SetBool("CloudVanish", false);
        hidden = false;
        returnTimer = returnTime;
    }


}
