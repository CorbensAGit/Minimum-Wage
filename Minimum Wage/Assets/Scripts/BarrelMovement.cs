using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(6, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onCollisionEnter2D(Collision2D col)
    {
        print("coll detected");
        if (col.otherCollider.name=="RWall")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-6, 0);
        }
         if (col.otherCollider.name=="LWall")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(6, 0);
        }
    }
}
