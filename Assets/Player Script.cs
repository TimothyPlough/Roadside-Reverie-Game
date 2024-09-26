using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;

    //smaller value means stop faster
    [Range(0f,1f)]
    [SerializeField] float drag;

    public float jump_speed;
    private bool can_jump;
    private float xInput;

    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //manages the inputs of the player
        GetInput();

        //checks input and jumps accordingly
        manageJump();

        //calls the correct animation
        manageAnimation();
    }
    private void FixedUpdate()
    {
        //manages horizontal movement and changes velocity accordingly
        playerMovement();
    }
    private void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
    }
    private void manageJump()
    {
        if (Input.GetKey(KeyCode.Space) && can_jump)
        {
            player.velocity = new Vector2(player.velocity.x, jump_speed);
            can_jump = false;
        }
    }
    private void playerMovement()
    {
        float increment = xInput * acceleration;
        float newSpeed = Mathf.Clamp(player.velocity.x + increment, -maxSpeed, maxSpeed);

        player.velocity = new Vector2(newSpeed,player.velocity.y);

        if (Mathf.Abs(xInput) > 0)
        {
            float direction = Mathf.Sign(xInput) * -1;
            transform.localScale = new Vector3(direction, 1, 1);
        }

        //only slowed down when on solid ground and no inputs
        if (can_jump && xInput == 0)
            player.velocity *= drag;
    }

    //manages animation conditions and values
    private void manageAnimation()
    {
        //if moving and on solid groud
        if (xInput != 0 && can_jump)
        {
            anim.SetBool("run", true);
        }
        else anim.SetBool("run", false);
        //falling animation if in air
        //idle animation
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
            can_jump = true;
        if (collision.gameObject.tag == "line")
            can_jump = true;
        if (collision.gameObject.tag == "square")
            can_jump = true;
    }
}
