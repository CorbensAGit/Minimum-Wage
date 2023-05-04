using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Vector2 left = new Vector2(-10, 0);
    private Vector2 right = new Vector2(10, 0);
    [SerializeField] private Rigidbody2D rb;
    public string direction = "R";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (direction == "R"){
            rb.velocity = right;
        } else {
            rb.velocity = left;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //print("coll detected");
        if (col.gameObject.name=="RWall")
        {
            rb.velocity = left; 
            direction = "L"; 
        }
        if (col.gameObject.name=="LWall")
        {
            rb.velocity = right;
            direction = "R";
        }
        if (col.gameObject.name=="EndBox")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy() 
    {
        SaveSystem.barrels.Remove(this);
    }

    void Awake()
    {
        SaveSystem.barrels.Add(this);
    }
}
