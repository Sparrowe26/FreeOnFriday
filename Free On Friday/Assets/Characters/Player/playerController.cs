using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public Vector2 movementInput;
    Rigidbody2D rb;
    public float offset = 0.05f;
    public float moveSpeed = 5f;
    public ContactFilter2D movementFilter;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    public bool hasKey;
    public bool hasPic;
    public bool canMove;


    //Instance for the bar to move
    [SerializeField] DetectionBar _detectionbar;
    [SerializeField] protected GameObject GameoverText;
    public FieldOfView FOV;


    // possesion keep track of original sprite
    [SerializeField] public Sprite ogSprite;
    private SpriteRenderer spriteRenderer;
    private GameObject possessed;
    public bool possessing;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasKey = false;
        hasPic = false;
        canMove = true;
        possessing = false;

        
        //stops player from colliding with interactables

       // movementFilter.SetLayerMask(LayerMask.GetMask("hgjvbasdfijkulgasdfguil"));
    }

    //Working on getting this to work - Ryan
    private void Update()
    {
        //if (FOV.isDetecting == true)
        //{
            //PlayerDetected(50);
            //Debug.Log(GameManager.gameManager._playerDetection.Detect);
        //}
    }


    private void FixedUpdate()
    {
        if(canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if (!success)
                    {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }


            }
        }

    }

    private bool TryMove(Vector2 direction)
    {
        //check for collisions
        int count = rb.Cast(
            direction, 
            movementFilter, 
            castCollisions, 
            moveSpeed * Time.fixedDeltaTime + offset);

        if(count==0)
        {
            //move
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue moveValue)
    {
        movementInput = moveValue.Get<Vector2>();
    }


    //if player is detected update what is needed
    public bool PlayerDetected(int amount)
    {
        GameManager.gameManager._playerDetection.DectectionUnit(amount);
        _detectionbar.SetDetection(GameManager.gameManager._playerDetection.Detect);
        if (GameManager.gameManager._playerDetection.Detect == 100)
        {
            GameManager.gameManager._playerDetection.Detect = 0;
            _detectionbar.SetDetection(GameManager.gameManager._playerDetection.Detect);
            return true;
        }
        else
            return false;
    }
 

    public void ResetSprite()
    {
       //spriteRenderer.sprite = ogSprite;
    }

    public void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

}
