using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCAnimationController : MonoBehaviour
{
    public GameObject child;
    public AIPath aiPath;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isWalking;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void onMovement()
    {
        // movement = playerController.Get<Vector2>();
        movement = aiPath.velocity;
        Console.WriteLine(movement);

       if (movement.x >= 0.25 || movement.y >= 0.25)
       {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
       }
       else
       {
            animator.SetBool("IsWalking", false);
       }

    }

    private void Update()
    {

        onMovement();
    }
}
