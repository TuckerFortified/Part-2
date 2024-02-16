using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //This function relaods the first scene
    public void PlayAgain() 
    {
        SceneManager.LoadScene(3);
    }
}
