using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody2D rb;
    public float offset = 0.05f;
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)  
        {
            //check for collisions
            int count = rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime * offset);

            if(count==0)
            {
                //move
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }

            
        }
    }

    void onMove(InputValue moveValue)
    {
        movementInput = moveValue.Get<Vector2>();
    }
 
}
