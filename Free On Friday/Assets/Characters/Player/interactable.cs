using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class interactable : collidable
{

    bool interacted = false;

    protected override void OnCollide(GameObject collidedObj)
    {
        text.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {

            onInteract();
        }


    }

    private void onInteract()
    {
        if(!interacted)
        {
            Debug.Log("inter");
            spriteRend.gameObject.SetActive(false);
            interacted = true;
        }
        
    }


}
