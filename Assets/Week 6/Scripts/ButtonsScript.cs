using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    
    public void NextScene()
    {
        SceneManager.LoadScene(2);
    }

    public void sixteenXNine()
    {
        Screen.SetResolution(1600, 900, false);
    } 
        
    public void HD()
    {
        Screen.SetResolution(1920, 1080, false);
    }

}
