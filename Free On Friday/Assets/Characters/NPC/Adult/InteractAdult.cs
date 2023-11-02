using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAdult : interactable
{

    protected override void onInteract()
    {
        if (!interacted)
        {
            Player.GetComponent<SpriteRenderer>().sprite = this.spriteRend.sprite;
            Player.GetComponent<Transform>().localScale = new Vector2(.35f,.35f);
            interacted = true;
        }
        else
        {
            this.transform.position = Player.transform.position;
            spriteRend.enabled = true;
            Player.GetComponent<playerController>().ResetSprite();
        }
    }
}
