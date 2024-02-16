using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bar : MonoBehaviour
{
    public Slider healthBar;

    private void Start()
    {
        //This code makes it so the health starts at 10
        healthBar.value = 10;
    }

    //This code changes the health bar value depending on who touches the player
    public void ChangeHealthValue(float i)
    {
        healthBar.value = healthBar.value + i;
    }
}
