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


    
    void Start()
    {
        //This code makes the object start at a random position
        transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This code resets the animation curve and changes the move coordinates
        startPos = transform;
        int count = Random.Range(1, 5);
        if (count == 1)
        {
            endPos = endPos1;
        }
        else if (count == 2)
        {
            endPos = endPos2;
        }
        else if (count == 3)
        {
            endPos = endPos3;
        }
        else if (count == 4)
        {
            endPos = endPos4;
        }
        else if (count == 5)
        {
            endPos = endPos5;
        }

        //This line resets the animation curve, reseting the animation for moving.
        lerpTimer = 0;
    }

    
    void Update()
    {
        //This code makes the animation curve move
        interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPos.position, endPos.position, interpolation);
        lerpTimer = lerpTimer + Time.deltaTime;
    }
}
