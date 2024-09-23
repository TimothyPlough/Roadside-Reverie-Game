using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D player;
    Vector2 movement;
    public float move_speed;
    public float jump_height;

    private bool can_jump;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1,-1.5f,0);
        player = GetComponent<Rigidbody2D>();

        can_jump = true;
    }
    // Update is called once per frame
    void Update()
    {
        player.velocity = new Vector2(
            Input.GetAxisRaw("Horizontal") * move_speed,
            player.velocity.y);

        if(Input.GetKey(KeyCode.Space) && can_jump)
        {
            Jump();
        }

    }
    private void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jump_height);
        can_jump = false;
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
