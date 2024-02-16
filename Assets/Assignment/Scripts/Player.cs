using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Vector2 destination;
    Vector2 movement;
    Animator animator;
    public float speed;



    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

  
    void Update()
    {
        //This script activates when the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //The destination is set to the current mouse posisiton
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        //This code moves the player towards the destination
        movement = destination - (Vector2)transform.position;
        rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.deltaTime);
    }
}
