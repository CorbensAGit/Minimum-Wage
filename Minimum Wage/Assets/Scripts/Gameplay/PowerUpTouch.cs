using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpTouch : ScriptableObject
{
    public abstract void Apply(Player player);
}
