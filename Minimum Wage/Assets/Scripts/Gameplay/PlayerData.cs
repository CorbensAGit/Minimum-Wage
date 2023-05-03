using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    public int lives;
    public float[] position;

    public PlayerData (Player player) {
        lives = player.lives;
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
