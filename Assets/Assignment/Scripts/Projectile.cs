using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed;
    Vector3 currentPosition;
    bool isPlayer = false;

    void Start()
    {
        //This code makes the projectile start at a random Y-coordinate
        transform.position = new Vector3(14, Random.Range(-5, 5), 0);

        currentPosition = transform.position;

        speed = Random.Range(1, 10);
    }

    private void FixedUpdate()
    {
        currentPosition.x = currentPosition.x - speed * Time.deltaTime;
        transform.position = currentPosition;
    }



    void Update()
    {
        
    }
}
