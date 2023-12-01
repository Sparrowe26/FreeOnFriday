using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactKey : interactable
{

    public bool picked;
   
    protected override void onInteract()
    {
        if (!interacted)
        {

           /* Player.GetComponent<playerController>().hasKey = true;*/
            picked = true;
            spriteRend.gameObject.SetActive(false);
            interacted = true;
        }
    }
}
