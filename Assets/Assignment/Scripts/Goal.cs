using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;


    // Start is called before the first frame update
    void Start()
    {
        //This code makes the object start at a random position
        transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
