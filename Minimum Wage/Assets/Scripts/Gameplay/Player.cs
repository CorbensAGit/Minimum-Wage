using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 start = new Vector2(98, 57);
    public int lives = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Death")
        {
            if (lives > 0) {
                Debug.Log("player hit");
                takeLife();
                transform.position = start;
            } else {
                Debug.Log("player dead");
                Destroy(gameObject);
            }
            
        }
    }

    public void takeLife() {
        lives--;
    }

    public void SavePlayer() 
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();

        lives = data.lives;
        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
    }
}
