using System.Collections;
using System.Collections.Generic;

using System.Reflection;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class interactable : collidable
{
    [SerializeField] bool isKey;
    [SerializeField] bool isDoor;
    [SerializeField] bool isPic;
    bool interacted = false;

    protected override void OnCollide(GameObject collidedObj)
    {
        if(collidedObj.name == "StandinPlayer" )
        {
            text.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {




                if (isKey)
                {
                    Player.GetComponent<playerController>().hasKey = true;
                }

                if (isPic)
                {
                    Player.GetComponent<playerController>().hasPic = true;
                }

                if (isDoor)
                {
                    if(Player.GetComponent<playerController>().hasKey)
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

    private void onInteract()
    {
        if(!interacted)
        {
            
           
            spriteRend.gameObject.SetActive(false);
            interacted = true;
        }
        
    }


}
