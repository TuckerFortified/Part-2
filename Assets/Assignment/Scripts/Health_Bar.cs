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
        healthBar.value = 10;
    }
    public void ChangeHealthValue(float i)
    {
        healthBar.value = healthBar.value + i;
    }
}
