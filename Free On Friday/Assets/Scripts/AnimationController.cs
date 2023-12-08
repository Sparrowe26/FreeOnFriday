using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    public playerController playerController;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void onMovement()
    {
        //movement = playerController.Get<Vector2>();
        movement = playerController.movementInput;
      
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }
        else
        {
             animator.SetBool("IsWalking", false);
        }

        if (playerController.possessing == true)
        {
            animator.SetBool("IsPossessing", true);
        }
        else
        {
            animator.SetBool("IsPossessing", false);
        }

    }

    private void Update()
    {

        onMovement();
    }
}
