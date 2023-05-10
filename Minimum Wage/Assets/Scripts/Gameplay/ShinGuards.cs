using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinGuard : PowerUp
{
    public override void Use(Player player)
    {
        player.shinGuardAvailable = true;
    }

    public override void TakeDuration()
    {
        // duration--;
    }
}
