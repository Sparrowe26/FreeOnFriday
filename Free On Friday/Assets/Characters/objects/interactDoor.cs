using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class interactDoor : interactable
{

   

    [SerializeField] public bool isOpen;
    protected override void onInteract()
    {
        GameObject doorObject = Player.transform.GetChild(0).gameObject;
       
        if (!interacted)
        {

            if (!isOpen)
            {
                if (Player.GetComponent<playerController>().hasKey)
                {
                    doorObject.GetComponent<SpriteRenderer>().gameObject.SetActive(false);
                    interacted = true;
                    isOpen = true;
                    
                }
            }
            else
            {
                doorObject.GetComponent<SpriteRenderer>().gameObject.SetActive(true);
                isOpen = false;
            }
            
            
        }
    }
}
