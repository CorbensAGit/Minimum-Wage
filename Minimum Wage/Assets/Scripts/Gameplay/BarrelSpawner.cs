using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] GameObject barrel;

    // Update is called once per frame
    void Start () 
    {
        InvokeRepeating("SpawnBarrel", 0.2f, 3.0f);
    }

    void SpawnBarrel ()
    {
        Instantiate(barrel, transform.position, Quaternion.identity); 
    }
    
    
}
