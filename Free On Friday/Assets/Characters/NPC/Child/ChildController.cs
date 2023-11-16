using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChildController : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;
    private bool detected = false;
    private GameObject parent;

    public Vector3 DirFromAngle(float angleDeg)
    {
        return new Vector2(Mathf.Sin(angleDeg * Mathf.Deg2Rad), Mathf.Cos(angleDeg * Mathf.Deg2Rad));
    }

    private void Start()
    {
        parent = GameObject.Find("parent");
    }

    private void Update()
    {
        if (detected)
        {
            if (GetComponent<IAstarAI>().reachedDestination)
            {
                Debug.Log("finished");
            }
        }
    }

    public void Detected()
    {
        GetComponent<AIDestinationSetter>().target = parent.transform;
        detected = true;
    }
}
