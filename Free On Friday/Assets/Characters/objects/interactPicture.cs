using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactPicture : interactable
{
    // Start is called before the first frame update
    protected override void onInteract()
    {
        if (!interacted)
        {

            Player.GetComponent<playerController>().hasPic = true;

            spriteRend.gameObject.SetActive(false);
            interacted = true;
        }
    }
}
