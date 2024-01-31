using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed = 1;
    public AnimationCurve landing;
    float landingTimer;
    Vector2 pos;
    SpriteRenderer spriteRenderer;
    int rand;
    public List<Sprite> spriteList;
    float tooClose = 0.5f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();
        pos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        speed = Random.Range(1, 3);
        int rand = Random.Range(1, 4);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteList[rand - 1];
        
        

    }

    void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
        
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0 )
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

    }

    void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount -1, newPosition);
            lastPosition = newPosition;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float dist = Vector3.Distance(transform.position, collision.transform.position);
        if (dist < tooClose)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }

}
