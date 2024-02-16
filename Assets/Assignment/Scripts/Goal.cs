using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    Transform startPos;
    public Transform endPos1;
    public Transform endPos2;
    public Transform endPos3;
    public Transform endPos4;
    public Transform endPos5;
    Transform endPos;
    public AnimationCurve animationCurve;
    public float lerpTimer;
    public float interpolation;
    bool isMoving;
    Vector2 oppositeDirection;
    Vector2 lastPosition;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;


    
    void Start()
    {
        //This code makes the object start at a random position
        transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);

        lastPosition = transform.position;

        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Chacking if the object that is colliding is the player (using a tag)
        if (collision.CompareTag("Player"))
        {
            //This code resets the animation curve and changes the move coordinates
            startPos = transform;
            int count = Random.Range(1, 5);
            if (count == 1 && endPos != endPos1)
            {
                endPos = endPos1;
            }
            else if (count == 2 && endPos != endPos2)
            {
                endPos = endPos2;
            }
            else if (count == 3 && endPos != endPos3)
            {
                endPos = endPos3;
            }
            else if (count == 4 && endPos != endPos4)
            {
                endPos = endPos4;
            }
            else
            {
                endPos = endPos5;
            }

            //This line resets the animation curve, reseting the animation for moving.
            lerpTimer = 0;

            //This sends a message to the player to add 1 health
            collision.SendMessage("ChangeHealthValue", 1);

            //This sends a message to the score, telling it to add 1 point
            SendMessage("Increment", SendMessageOptions.DontRequireReceiver);
        }


    }

    
    void Update()
    {
        //This code makes the animation curve move
        interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPos.position, endPos.position, interpolation);
        lerpTimer = lerpTimer + Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //This code will change the rotation of the Goal, so that it is facing its previos position
        currentPosition = transform.position;
        Vector2 oppositeDirection = lastPosition - currentPosition;
        float angle = Mathf.Atan2(oppositeDirection.x, oppositeDirection.y) * Mathf.Rad2Deg;
        rigidbody.rotation = -angle; 
    }
}
