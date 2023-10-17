using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class interactable : collidable
{
    protected override void OnCollide(GameObject collidedObj)
    {
        if(Input.GetKey(KeyCode.E))
        {
            onInteract();
        }


    }

    private void onInteract()
    {
        Debug.Log("inter");
    }


}
