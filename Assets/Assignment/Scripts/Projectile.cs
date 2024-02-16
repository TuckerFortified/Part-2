using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.ShaderKeywordFilter;

public class Projectile : MonoBehaviour
{
    float speed;
    Vector3 currentPosition;
    //public GameObject gameObject;

    void Start()
    {
        //This code makes the projectile start at a random Y-coordinate
        transform.position = new Vector3(14, Random.Range(-5, 5), 0);

        currentPosition = transform.position;

        //This code makes the projectiles start with a random speed
        speed = Random.Range(1, 10);
    }

    private void FixedUpdate()
    {
        //This code moves the projectiles left
        currentPosition.x = currentPosition.x - speed * Time.deltaTime;
        transform.position = currentPosition;

        //This code destorys the projectile after it leaves the screen
        if (currentPosition.x < -15)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This code checks if the object entering the trigger is the player
        if (collision.CompareTag("Player"))
        {
            //This code damages the player and destroys the projectile if it touches the player
            collision.SendMessage("ChangeHealthValue", -1);
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}
