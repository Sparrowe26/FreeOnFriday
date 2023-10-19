using System.Collections;
using System.Collections.Generic;

using System.Reflection;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class interactable : collidable
{
    [SerializeField] bool isKey;
    [SerializeField] bool isDoor;
    bool interacted = false;

    //does interactions when player is near
    protected override void OnCollide(GameObject collidedObj)
    {
        if(collidedObj.name == "StandinPlayer")
        {
            text.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log(collidedObj.name);
                if(isKey)
                {
                    Player.GetComponent<playerController>().hasKey = true;
                }
                if(isDoor) 
                {
                    if (Player.GetComponent<playerController>().hasKey)
                    {
                        onInteract();
                    }
                }
                else
                {
                    onInteract();
                }
                
            }
        }
        
        


    }

    //deactivates interacted object
    private void onInteract()
    {
        if(!interacted)
        {
            
           
            spriteRend.gameObject.SetActive(false);
            interacted = true;
        }
        
    }


}
