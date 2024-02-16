using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float MaxTime = 5;
    float time = 0;
    float timer;
    public GameObject projectile;

   
    void Start()
    {
        //Sets the time to a random value
        timer = Random.Range(0.2f, MaxTime);
    }

    private void FixedUpdate()
    {
        //This code checks if the timer has been completed, then spawns a projectile
        //It also slowly makes it so projectiles spawn faster over time.
        if (time > timer) 
        {
            time = 0;
            MaxTime = MaxTime - 0.1f;
            Instantiate(projectile);
            timer = Random.Range(0.2f, MaxTime);
        }

        //This line of code incriments the time    
        time = time + Time.deltaTime;
    }
    
}
