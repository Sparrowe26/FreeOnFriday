using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour
{
    private Vector3 prevLoc = new Vector3(0, 0, 0);
    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0) - prevLoc);
        //gameObject.transform.parent.gameObject.GetComponent<AstarPath>().;
        //gameObject.transform.Rotate(new Vector3(0,0,1), (gameObject.transform.position - prevLoc).normalized);
        prevLoc = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
