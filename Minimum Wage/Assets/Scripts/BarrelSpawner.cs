using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;
    public int count = 2100;
    // Update is called once per frame
    void Update() 
    {
        count--;
        if (count <= 0)
        {
            Instantiate(barrelPrefab, transform.position, Quaternion.identity);
            count = 2100;
        }
    }

}
