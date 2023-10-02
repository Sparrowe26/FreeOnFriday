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
    public float moveSpeed;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {
            rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime * offset);
        }
    }

    void onMove(InputValue moveValue)
    {
        movementInput = moveValue.Get<Vector2>();
    }
 
}
