using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class gameover : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<IAstarAI>().reachedDestination)
            Debug.Log("lose");
    }
}
