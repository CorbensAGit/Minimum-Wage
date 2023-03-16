using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;
    public int timeDelay = 5;
    // Update is called once per frame

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(barrelPrefab, transform.position, Quaternion.idenity);
        }
    }

}
