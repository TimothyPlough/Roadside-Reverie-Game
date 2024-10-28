using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerCollider;
    [SerializeField] Rigidbody2D player;
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;

    //smaller value means stop faster
    [Range(0f,1f)]
    [SerializeField] float drag;

    [SerializeField] BoxCollider2D platformCheck;
    public float jump_speed;
    public float playerDownY = 0.1f;
    public bool can_jump;
    private float xInput;
    private bool isStun;
    [SerializeField] float knockback;
    [SerializeField] float stunTime;
    private float stunCount;

    private GameObject currentPlatform;

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

        //regulates when the player is stunned
        checkStun();
    }

    private void FixedUpdate()
    {
        //manages horizontal movement and changes velocity accordingly
        playerMovement();

        //calls the correct animation
        manageAnimation();
    }

    private void GetInput()
    {
        if(!isStun)
            xInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
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

        //change sprite direction
        if (Mathf.Abs(xInput) > 0)
        {
            float direction = Mathf.Sign(xInput) * -1;
            transform.localScale = new Vector3(direction, 1, 1);
        }

        //only slowed down when on solid ground and no inputs
        if (can_jump && xInput == 0)
            if (Input.GetKey(KeyCode.DownArrow))
            {
                player.position = new Vector2(player.position.x, player.position.y - playerDownY);
                can_jump = false;
            }
            else
            {
                player.velocity *= drag;
            }
            
    }

    private void Stun()
    {
        player.velocity = new Vector2(knockback, player.velocity.y);
        xInput = 0;
        isStun = true;
        stunCount = stunTime;
    }

    private void checkStun()
    {
        if (isStun && stunCount > 0)
        {
            stunCount -= Time.deltaTime;
            Debug.Log("Stun time left: " + stunCount);
        }
        else
        {
            isStun = false;
        }
    }

    //manages animation conditions and values
    private void manageAnimation()
    {

        //if moving and on solid groud
        if (xInput != 0) 
            anim.SetBool("PlayerRun", true);
        else  
            anim.SetBool("PlayerRun", false);

        //falling animation if in air
        anim.SetBool("InAir", !can_jump);

        //stun animation
        anim.SetBool("Stunned", isStun);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = playerCollider.bounds.center;

        if (contactPoint.y < center.y)
        {
            if (collision.gameObject.tag == "platform")
            {
                can_jump = true;
                currentPlatform = collision.gameObject;
            }
            if (collision.gameObject.tag == "line")
                can_jump = true;
            if (collision.gameObject.tag == "square")
                can_jump = true;
        }
        if (collision.gameObject.tag == "obstacle")
            Stun();
    }

    private void OnCollisionExit2D(Collision2D platformCheck)
    {
        currentPlatform = null;
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
