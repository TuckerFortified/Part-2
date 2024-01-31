using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectScript : MonoBehaviour
{
    float timer;
    float timerTarget;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        timerTarget = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= timerTarget)
        {
            timer = 0;
            timerTarget = (Random.Range(1, 5));
            Instantiate(prefab);
        }
        timer += Time.deltaTime;
    }
}
