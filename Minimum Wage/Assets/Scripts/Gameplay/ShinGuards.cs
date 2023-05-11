using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinGuard : PowerUp
{
    public int duration = 2;
    public Player player;

    public override void BecomeAvaliable()
    {
        player.shinGuardAvailable = true;
    }

    public override void Use(Player player)
    {
        player.shinGuardAvailable = true;
    }

    public override void TakeDuration()
    {
        duration--;
    }

    public override void EndPowerUp()
    {
        player.shinGuardAvailable = false;
    }
}
