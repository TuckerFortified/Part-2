using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scorePoints;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string PointsText = "Score: " + score;
        scorePoints.text = PointsText;
    }

    public void Increment() 
    {
        score = score+1;
    }
}
