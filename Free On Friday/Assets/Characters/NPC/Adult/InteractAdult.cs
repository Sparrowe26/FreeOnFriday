using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class InteractAdult : interactable
{
    public bool possessed = false;
    [SerializeField] public Sprite ogSprite;

    protected override void Update()
    {
        if (text != null)
            text.SetActive(false);
        colliderBox.OverlapCollider(filter, collidedObj);
        foreach (var o in collidedObj)
        {
            OnCollide(o.gameObject);
        }
        if(possessed)
        {
            this.gameObject.transform.position = Player.gameObject.transform.position;
        }
    }

    protected override void onInteract()
    {
        if (!interacted)
        {
            if(!possessed)
            {
                Player.GetComponent<SpriteRenderer>().sprite = this.spriteRend.sprite;
                Player.gameObject.transform.position = this.gameObject.transform.position;
                spriteRend.enabled = false;
                interacted = true;
                possessed = true; 
                Player.GetComponent<playerController>().possessing = true;
                Invoke("interactDelay", .2f);
            }
             else
            {
                this.transform.position = Player.transform.position;
                spriteRend.enabled = true;
                Player.GetComponent<SpriteRenderer>().sprite = ogSprite;
                interacted = true;
                possessed = false;
                Player.GetComponent<playerController>().possessing = false;
                Invoke("interactDelay", .2f);
            }
        }
       
    }
}
