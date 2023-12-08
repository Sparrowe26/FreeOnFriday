using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactKid : interactable
{


    [SerializeField] protected GameObject pic;
    [SerializeField] protected GameObject spriteHolder;


    protected override void onInteract()
    {
       
        if (!interacted)
        {
            if (pic.GetComponent<interactPicture>().picked)
            {
                Debug.Log("picked");

                this.spriteRend.gameObject.SetActive(false);
                spriteHolder.SetActive(false);
                interacted = true;
                
            }

        }
    }
}
