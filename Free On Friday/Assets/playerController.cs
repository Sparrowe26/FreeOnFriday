using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Vector2 movementInput;
    // Start is called before the first frame update
    void Start()
    {
        
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

   /* void OnMove(InputValue moveValue)
    {
        movementInput = moveValue.Get<Vector2>();
    }*/
}
