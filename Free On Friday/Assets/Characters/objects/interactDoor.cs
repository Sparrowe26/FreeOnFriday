using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactDoor : interactable
{
    [SerializeField] public bool isOpen;
    protected override void onInteract()
    {
        if (!interacted)
        {

            if (!isOpen)
            {
                if (Player.GetComponent<playerController>().hasKey)
                {
                    //spriteRend.gameObject.SetActive(false);
                    interacted = true;
                    isOpen = true;
                }
            }
            else
            {
                isOpen = false;
            }
            
            
        }
    }
}
