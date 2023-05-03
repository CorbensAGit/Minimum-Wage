using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public int lives = 2;
    public Vector2 start = new Vector2(98, 57);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Death")
        {
            if (lives > 0) {
                Debug.Log("player hit");
                lives--;
                transform.position = start;
            } else {
                Debug.Log("player dead");
                Destroy(gameObject);
            }
            
        }
    }
}
