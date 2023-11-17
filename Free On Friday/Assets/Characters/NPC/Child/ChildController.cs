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
        parent = GameObject.Find("Adult");
    }

    private void Update()
    {
        if (detected)
        {
            if (GetComponent<IAstarAI>().reachedDestination)
            {
                Debug.Log("finished");
                GameObject.Find("Adult").GetComponent<FieldOfView>().enabled = true;
            }
        }
    }

    public void Detected()
    {
        GetComponent<AIDestinationSetter>().enabled = true;
        GetComponent<AIDestinationSetter>().target = parent.transform;
        detected = true;
    }
}
