using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<IAstarAI>().reachedDestination)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("lose");
        }
    }
}
