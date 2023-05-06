using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int value;
    public Player player;
    System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {  
        value  = random.Next(1, 4)*5;  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        player.AddCash(value);

        Destroy(gameObject);
    }

    void Awake()
    {
        SaveSystem.money.Add(this);
    }

    void OnDestroy() 
    {
        SaveSystem.money.Remove(this);
    }

    public void KillYourself()
    {
        Destroy(gameObject);
    }
}
