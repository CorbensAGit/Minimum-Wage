using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BarrelData
{
   public float[] position;
   public string direction;
   public float[] velocity;

   public BarrelData(Barrel barrel)
   {
    position = new float[2];
    position[0] = barrel.transform.position.x;
    position[1] = barrel.transform.position.y;

    velocity = new float[2];
    velocity[0] = barrel.rb.velocity.x;
    velocity[1] = barrel.rb.velocity.y;
    direction = barrel.direction;
   } 
}
