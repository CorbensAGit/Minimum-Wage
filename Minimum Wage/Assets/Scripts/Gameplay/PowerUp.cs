using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp
{
    public abstract void BecomeAvaliable();

    public abstract void Use(Player player);

    public abstract void TakeDuration();

    public abstract void EndPowerUp();
}
