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
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
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
}
