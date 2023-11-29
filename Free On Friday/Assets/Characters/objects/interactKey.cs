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
        // If the key is picked up
        if (picked == true)
        {
            // Turn the text's game object "off"
            text.gameObject.SetActive(false);
        }
    }
}
