using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D playerRb;

    private Vector2 movement;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //UpdateAnimationMove();


    }

    private void FixedUpdate()
    {
        UpdateAnimationMove();
    }

    void UpdateAnimationMove()
    {
        if (movement != Vector2.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        playerRb.MovePosition(playerRb.position + movement.normalized * playerSpeed * Time.deltaTime);
    }
}
