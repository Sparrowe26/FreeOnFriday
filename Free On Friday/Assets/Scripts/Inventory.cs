using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public GameObject redKey;
    public GameObject blueKey;
    public GameObject startKey;

    public playerController huh;
    
    // Start is called before the first frame update
    void Start()
    {
        redKey.SetActive(false);
        blueKey.SetActive(false);
        startKey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (huh.hasKey == true)
        {
            redKey.SetActive(true);
        }
    }
}
