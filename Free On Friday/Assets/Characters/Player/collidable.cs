using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;


//script for checking for collision 
//inherited by interactable
public class collidable : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D colliderBox;
    [SerializeField] private ContactFilter2D filter;
    private List<Collider2D> collidedObj = new List<Collider2D>(1);


    protected virtual void Start()
    {
        colliderBox = GetComponent<Collider2D>();

    }

    // Update is called once per frame

    protected virtual void Update()
    {
        colliderBox.OverlapCollider(filter, collidedObj);
        foreach (var o in collidedObj)
        {
            OnCollide(o.gameObject);
        }
    }

    protected virtual void OnCollide(GameObject collidedObj)
    {

    }
}

