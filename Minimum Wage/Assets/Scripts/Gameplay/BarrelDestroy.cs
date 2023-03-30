using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDestroy : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="EndBox")
        {
            Destroy(gameObject);
        }
    }
}
