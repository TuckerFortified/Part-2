using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    float GoalDistance = 2;
    public Rigidbody2D rb;
    Vector2 dir;
    Vector2 CenterLine;
    Vector2 Destination;
    void Start()
    {
       CenterLine = transform.position;
    }

 
    void FixedUpdate()
    {
        

        dir = (Vector2)Controller.CurrentSelection.transform.position - CenterLine;
        if (dir.magnitude > GoalDistance * 2)
        {
            Destination = CenterLine + dir.normalized * GoalDistance;

        }
        else
        {
            Destination = CenterLine + dir / 2;
            
        }
        rb.position = Vector2.MoveTowards((Vector2)rb.position, Destination, 0.05f);
    }
}
