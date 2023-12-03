using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFollow : MonoBehaviour
{
    public Transform Follow;
    public float offset = 0.5f;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Follow.transform.position.x, Follow.transform.position.y - offset, Follow.transform.position.z);
    }
}
