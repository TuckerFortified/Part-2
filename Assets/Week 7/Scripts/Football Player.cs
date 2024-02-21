using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class FootballPlayer : MonoBehaviour
{
    public Color Select;
    public Color Deselect;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody;
    public float Speed = 100;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Controller.SetCurrentSelection(this);
        
        
    }


    public void Selected(bool IsSelected)
    {
        if (IsSelected) 
        {
            spriteRenderer.color = Select;
        }

        if (IsSelected == false)
        {
            spriteRenderer.color = Deselect;
        }
    }

    public void Move(Vector2 Direction)
    {
        rigidbody.AddForce(Direction * Speed, ForceMode2D.Impulse);
    }
}
