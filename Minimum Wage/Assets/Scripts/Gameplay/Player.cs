using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lives = 2;
    public int[] powerups;

    public void takeLife() {
        lives--;
    }


}
