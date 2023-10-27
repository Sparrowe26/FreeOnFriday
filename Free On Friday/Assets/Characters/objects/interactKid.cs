using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactKid : interactable
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
