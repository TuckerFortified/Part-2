using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Vector2 destination;
    Vector2 movement;
    Animator animator;
    public float speed;
    float lastY = 0;
    int Health;
    int MaxHealth = 10;


    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Health = MaxHealth;
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
        if (movement.magnitude < 0.1) 
        {
            movement = Vector2.zero;
        }
        rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.deltaTime);
        //This code changes compares the previous and current values of X and Y, then changes the animation values based on it
        animator.SetFloat("Vertical", transform.position.y - lastY);
        animator.SetFloat("Speed", movement.magnitude);
        lastY = transform.position.y;
    }

    //This function controls how much health the player takes/receives. 
    //It also checks if the health is below 0, and if so, loads the death screen.
    public void ChangeHealthValue(int i)
    {
        Health = Health - i;
        if (Health <= 0)
        {
            //SceneManager.LoadScene();
        }
    }


}
