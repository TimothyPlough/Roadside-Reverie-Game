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

    public float jump_speed;
    private bool can_jump;
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

        //calls the correct animation
        manageAnimation();

        //regulates when the player is stunned
        checkStun();
    }
    private void FixedUpdate()
    {
        //manages horizontal movement and changes velocity accordingly
        playerMovement();
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
            player.velocity *= drag;
    }

    private void stun() //*reminder* missing stun animation
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
        if (xInput != 0 && can_jump)
        {
            anim.SetBool("run", true);
        }
        else anim.SetBool("run", false);
        //falling animation if in air
        //idle animation
        //stun animation
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
        if (collision.gameObject.tag == "obstacle")
            stun();
    }

    private void OnCollisionExit2D(Collision2D collision)
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
