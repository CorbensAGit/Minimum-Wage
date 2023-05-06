using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoneyData
{
    public float[] position;
    public int value;

    public MoneyData(Money money)
    {
        value = money.value;
        position = new float[2];
        position[0] = money.transform.position.x;
        position[1] = money.transform.position.y;
    }
}
