using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactDoor : interactable
{
    protected override void onInteract()
    {
        if (!interacted)
        {
            if (Player.GetComponent<playerController>().hasKey)
            {
                Player.GetComponent<playerController>().hasKey = true;

                spriteRend.gameObject.SetActive(false);
                interacted = true;
            }
            
        }
    }
}
