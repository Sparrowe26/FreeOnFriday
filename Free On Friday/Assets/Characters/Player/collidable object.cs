using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactor : MonoBehaviour
{
    private Collider2D colliderBox;
    private ContactFilter2D filter;
    private List<Collider2D> collidedObj;

    // Start is called before the first frame update
    void Start()
    {
        colliderBox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        colliderBox.OverlapCollider(filter,collidedObj);
        foreach(var o in collidedObj)
        {
            Debug.Log(o.name);
        }
    }
}
