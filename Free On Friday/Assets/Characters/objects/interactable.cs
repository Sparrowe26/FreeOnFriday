using System.Collections;
using System.Collections.Generic;

using System.Reflection;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class interactable : collidable
{
    
   
    [SerializeField] bool isPic;
    protected bool interacted = false;

    protected override void OnCollide(GameObject collidedObj)
    {
        if(collidedObj.name == "StandinPlayer" )
        {
            if (text != null)
                text.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {

                if (isPic)
                {
                    Player.GetComponent<playerController>().hasPic = true;
                }

               
                else
                {
                    onInteract();
                }

                
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


}
