using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/ShinGuard")]

public class ShinGuard : PowerUpTouch
{
    public override void Apply(Player player)
    {
        player.shinGuardAvailable = true;
    }
}
