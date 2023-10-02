using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2d>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {

        }
    }

    void onMove(InputValue moveValue)
    {
        movementInput = moveValue.Get<Vector2>();
    }
 
}
