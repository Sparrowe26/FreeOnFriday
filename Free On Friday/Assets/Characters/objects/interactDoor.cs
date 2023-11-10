using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class interactDoor : interactable
{

    [SerializeField]
    protected GameObject doorObject;


    [SerializeField]
    protected GameObject key;

    [SerializeField] public bool isOpen;
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
