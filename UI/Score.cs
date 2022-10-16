using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject highScorePanel;
    [SerializeField] ScoreObj scoreObj;

    private void Start()
    {
        highScorePanel.SetActive(false);
    }

    public void ActivatePanel(bool isActive)
    {
        highScorePanel.SetActive(isActive);
    }

    public int GetScore()
    {
        return score;
    }


    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();    
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")){

            score++;
            scoreObj.score = score;

        }
    }
}
