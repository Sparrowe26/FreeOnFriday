using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(new Vector3(gameObject.transform.forward.x, gameObject.transform.forward.y, 0));
    }
}
