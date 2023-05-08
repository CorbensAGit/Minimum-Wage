using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePoint
{
    public Vector2 position;
    public Quaternion rotation;
    
    public TimePoint (Vector2 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}
