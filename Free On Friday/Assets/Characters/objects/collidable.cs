using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;


//script for checking for collision 
//inherited by interactable
public class collidable : MonoBehaviour
{
    // Start is called before the first frame update
    protected Collider2D colliderBox;
    [SerializeField] protected ContactFilter2D filter;
    protected List<Collider2D> collidedObj = new List<Collider2D>(1);
    protected SpriteRenderer spriteRend;
    [SerializeField]
    protected GameObject text;
    protected GameObject Player;

    protected virtual void Start()
    {
        if(text != null)
        {
            text.SetActive(false);
        }
        colliderBox = GetComponent<Collider2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        
        Player = GameObject.Find("StandinPlayer");
    }

    // Update is called once per frame

    protected virtual void Update()
    {
        if (text != null)
            text.SetActive(false);
        colliderBox.OverlapCollider(filter, collidedObj);
        foreach (var o in collidedObj)
        {
            OnCollide(o.gameObject);
        }
    }

    protected virtual void OnCollide(GameObject collidedObj)
    {
        Debug.Log(collidedObj.name);
        spriteRend.color = Color.red;
    }
}

