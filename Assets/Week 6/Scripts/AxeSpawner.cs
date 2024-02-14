using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpawner : MonoBehaviour
{
    public GameObject objt;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
