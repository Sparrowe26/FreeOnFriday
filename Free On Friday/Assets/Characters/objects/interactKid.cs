using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactKid : interactable
{


    [SerializeField] protected GameObject pic;


    protected override void onInteract()
    {
        if (!interacted)
        {
            if (pic.GetComponent<interactPicture>().picked)
            {

                spriteRend.gameObject.SetActive(false);
                interacted = true;
            }

        }
    }
}
