using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactKey : interactable
{
   
    protected override void onInteract()
    {
        if (!interacted)
        {

            Player.GetComponent<playerController>().hasKey = true;

            spriteRend.gameObject.SetActive(false);
            interacted = true;
        }
    }
}
