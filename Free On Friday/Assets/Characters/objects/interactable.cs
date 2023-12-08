using System.Collections;
using System.Collections.Generic;

using System.Reflection;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class interactable : collidable
{
    protected bool textBool = false;
   
   
    protected bool interacted = false;

    protected override void OnCollide(GameObject collidedObj)
    {
        if(collidedObj.name == "StandinPlayer" )
        {
            if (text != null)
                text.SetActive(true);
                textBool = true;
            if (Input.GetKey(KeyCode.E))
            {
                    onInteract();
            }
        }
        


    }

    protected virtual void onInteract()
    {
        if(!interacted)
        {
            spriteRend.gameObject.SetActive(false);
            interacted = true;
        }

    }
    protected virtual void interactDelay()
    {
        interacted = false;
    }




}
