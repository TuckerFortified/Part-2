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
    void Start()
    {
       CenterLine = transform.position;
    }

 
    void FixedUpdate()
    {
        

        dir = (Vector2)Controller.CurrentSelection.transform.position - CenterLine;
        if (dir.magnitude > GoalDistance * 2)
        {
            rb.position = CenterLine + dir.normalized * GoalDistance;

        }
        else
        {
            rb.position = CenterLine + dir / 2;
        }
    }
}
