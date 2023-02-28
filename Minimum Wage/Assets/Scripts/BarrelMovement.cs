using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -6);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="left wall")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(6, 0);
        }
        if (collision.gameObject.name=="right wall")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-6, 0);
        }
    }
}
