using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactKid : interactable
{
    protected override void onInteract()
    {
        if (!interacted)
        {
            if (Player.GetComponent<playerController>().hasPic)
            {

                spriteRend.gameObject.SetActive(false);
                interacted = true;
            }

        }
    }
}
