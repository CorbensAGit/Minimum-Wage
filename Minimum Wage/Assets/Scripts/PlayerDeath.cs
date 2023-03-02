using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            print("player death script start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Barrel")
        {
            Destroy(gameObject);
        }
    }
}
