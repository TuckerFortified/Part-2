using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.OverlapPoint(collision.transform.position))
        {
            collision.GetComponent<Plane>().stopFly = true;
            score = score + 1;
        }
    }
}
