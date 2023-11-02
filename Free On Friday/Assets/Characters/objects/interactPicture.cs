using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class interactPicture : interactable
{
    [SerializeField]
    protected GameObject UIPic;
    // Start is called before the first frame update
    protected bool looking = false;
    protected override void onInteract()
    {
        if (!interacted)
        {
            if (!looking)
            {
                Player.GetComponent<playerController>().hasPic = true;

               // spriteRend.gameObject.SetActive(false);
                interacted = true;

                UIPic.SetActive(true);
                Player.GetComponent<playerController>().canMove = false;
                Invoke("interactDelay", .2f);
                looking = true;
            }
            else
            {
                UIPic.SetActive(false);
                Player.GetComponent<playerController>().canMove = true;
                interacted = true;
                looking = false;
                Invoke("interactDelay", .2f);
                

            }
            
        }
    }
}
