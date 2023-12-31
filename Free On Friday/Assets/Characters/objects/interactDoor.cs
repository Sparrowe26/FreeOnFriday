using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using Pathfinding;

public class interactDoor : interactable
{


    [SerializeField] protected GameObject doorObject;
    [SerializeField] protected GameObject key;
    [SerializeField] public bool isOpen;

    // Sound when door is not unlocked yet
    [SerializeField] public AudioClip shakeSound;
    [SerializeField] public AudioSource audioSource;

    private bool shaking = false;
    private float timer;
    private float shakeTime = .5f;
    private Vector3 originalPosition;
    bool up = false;
    int counter=0;

    protected override void Update()
    {
        if (text != null && textBool)
        {
            text.SetActive(false);
            textBool = false;
        }
            
        colliderBox.OverlapCollider(filter, collidedObj);
        foreach (var o in collidedObj)
        {
            OnCollide(o.gameObject);
        }

        //door shake 
        if (shaking)
        {
            var yOffset = .02f;

            if(up)
            {
                yOffset = -.02f;
               
            }
            else
            {
                 yOffset = .02f;
                
            }

            counter++;
            if(counter>50)
            {
                counter = 0;
                up = !up;
            }


            doorObject.gameObject.transform.position = originalPosition + new Vector3(0, yOffset, 0);
            timer += Time.deltaTime;
            if (timer > shakeTime)
            {
                shaking = false;
                doorObject.gameObject.transform.position = originalPosition;
                Invoke("interactDelay", .2f);

                // Plays the shaking sound via the audio source
                audioSource.PlayOneShot(shakeSound, 1);
            }

        }
    }


    protected override void onInteract()
    {
        
       
        if (!interacted)
        {

            if (!isOpen)
            {
                if (key.GetComponent<interactKey>().picked)
                {
                    doorObject.GetComponent<SpriteRenderer>().gameObject.SetActive(false);
                    interacted = true;
                    isOpen = true;
                    Invoke("interactDelay", .2f);
                }
                else
                {
                    originalPosition = doorObject.gameObject.transform.position; 
                    timer = 0;
                    shaking = true;
                
                    interacted = true;
                   
                }
            }
            else
            {
                doorObject.GetComponent<SpriteRenderer>().gameObject.SetActive(true);
                isOpen = false;
                interacted = true;
                Invoke("interactDelay", .2f);
            }
        }

    }

   

    
}
