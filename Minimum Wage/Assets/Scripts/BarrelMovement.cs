using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{
    private Vector2 left;
    private Vector2 right;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        left = new Vector2(-6, 0);
        right = new Vector2(6, 0);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = right;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //print("coll detected");
        if (col.gameObject.name=="RWall")
        {
            rb.velocity = left;  
        }
        if (col.gameObject.name=="LWall")
        {
            rb.velocity = right;
        }
    }
}
