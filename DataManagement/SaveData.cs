using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{

    [SerializeField] InputField nameInputField;
    [SerializeField] Score sc;

    SaveManager sm;
    GameManager gm;

    private string filepath;

    private void Awake()
    {
        filepath = Application.dataPath + "/PlayerDataFile.json";
        gm = FindObjectOfType<GameManager>();
    }

    //Saving the highest value in the inner highscores list and exporting it to a JSON file to have persistent data
    public void SaveInfoIntoJson()
    {
        if (File.Exists(filepath))
        {
            PlayerData pData = new PlayerData();

            pData.playerName = nameInputField.text;
            pData.playerPoints = sc.GetScore();

            string json = JsonUtility.ToJson(pData, true);

            sm.AddHighscore(pData);

            File.AppendAllText(filepath, json);

            gm.RestartGame();
        }
       
    }

}
