using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    GameObject game;
    public float time;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        game = rb.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= timer) 
        {
            Destroy(game);
        }
        time = time + Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(game);
    }
}
