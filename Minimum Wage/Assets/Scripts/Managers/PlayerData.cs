using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int lives;
    public float[] position;
    public int cash;
    public int time;

    public PlayerData (Player player) {
        lives = player.lives;
        cash = player.cash;
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        time = Player.playTime;

    }
}
