using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] Text panelScore;
    [SerializeField] Score sc;

    //Shows score when activating the window
    private void OnEnable()
    {
        panelScore.text = "SCORE: " + sc.GetScore().ToString();  
    }
}
