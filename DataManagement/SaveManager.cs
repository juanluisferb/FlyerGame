using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public List<PlayerData> highScore = new List<PlayerData>();
    private static bool created = false;
    public string filepath;
    private Score score;
    GameManager gm;

    [SerializeField] ScoreObj scoreObj;

    private void Awake()
    {
        filepath = Application.dataPath + "/PlayerDataFile.json";
        gm = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        //If there is no objects in the inner list, a blank one will be inserted to do the first comparison with the first result
        if (highScore.Count == 0)
        {
            PlayerData pData = new PlayerData();
            pData.playerName = "";
            pData.playerPoints = 0;

            AddHighscore(pData);

        }

        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    //Sorts high score from the inner list in the application
    public void SortHighscore()
    {
        for (int i = 0; i < highScore.Count; i++)
        {
            for (int j = i + 1; j < highScore.Count; j++)
            {
                if (highScore[j].playerPoints > highScore[i].playerPoints)
                {
                    PlayerData tmp = highScore[i];
                    highScore[i] = highScore[j];
                    highScore[j] = tmp;


                }

            }
        }
    }

    //Inserting a new high score (and sorting the list afterwards)
    public void AddHighscore(PlayerData pData)
    {
        highScore.Add(pData);
        SortHighscore();
    }

    public void ManageHighScorePanel()
    {


        if (highScore.Count > 0)
        {

            for (int i = 0; i < highScore.Count; i++)
            {
                if (scoreObj.score > highScore[i].playerPoints)
                {
                    gm.PauseGame();
                    score.ActivatePanel(true);

                }

            }
        }

        //At least one point is needed to get HighScore
        if (scoreObj.score == 0)
        {
            gm.LoseGame();
        }



    }
}
