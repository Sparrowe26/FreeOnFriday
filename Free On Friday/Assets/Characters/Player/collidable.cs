using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidable : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D colliderBox;
    [SerializeField] private ContactFilter2D filter;
    private List<Collider2D> collidedObj = new List<Collider2D>(1);


    void Start()
    {
        colliderBox = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        colliderBox.OverlapCollider(filter, collidedObj);
        foreach (var o in collidedObj)
        {
            Debug.Log(o.name);
        }
    }
}

