using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;

    // Update is called once per frame
    void Start () 
    {
        InvokeRepeating("SpawnBarrel", 0.2f, 3.0f);
    }

    void SpawnBarrel ()
    {
        Instantiate(barrelPrefab, transform.position, Quaternion.identity);
    }

}
