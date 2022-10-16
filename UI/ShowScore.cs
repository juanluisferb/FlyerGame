using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{

    private Text scoreTextGameOver;
    [SerializeField] ScoreObj score;

    private void Awake()
    {
        scoreTextGameOver = GetComponent<Text>();
    }


    private void Start()
    {

        scoreTextGameOver.text = "PUNTUACION: " + score.score.ToString();
    }

}
