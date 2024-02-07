using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    public float speed;
    Animator animator;
    bool clickSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead = false;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;
        if(movement.magnitude < 0.1) 
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if(Input.GetMouseButtonDown(0) && !clickSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
    }

    private void OnMouseDown()
    {
        if (isDead) return;
        clickSelf = true;
        TakeDamage(1);
        healthBar.TakeDamage(1);


    }

    private void OnMouseUp()
    {
        clickSelf = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("Take Damage");
        }
       

    }
}
