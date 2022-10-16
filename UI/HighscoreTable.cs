using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{


    [SerializeField] Transform entryList;
    [SerializeField] Transform entryBlank;
    private List<PlayerData> highScorePlayerData;
    private List<Transform> highScoreTransform;
    SaveManager sm;

    private void Awake()
    {
        sm = FindObjectOfType<SaveManager>();
        entryBlank.gameObject.SetActive(false);
    }

    private void Start()
    {

        highScoreTransform = new List<Transform>();

        string jsonString = File.ReadAllText(sm.filepath);
        PlayerData pData = JsonUtility.FromJson<PlayerData>(jsonString);

        //this generates an entry in the highscore table for each PlayerData object in the inner list generated in runtime
        foreach (PlayerData data in sm.highScore)
        {
            AddEntry(pData, highScoreTransform, entryList);
        }

    }

    //Adds an entry transform with all the data extracted from the PlayerData list
    private void AddEntry(PlayerData data, List<Transform> transformList, Transform listContainer)
    {
        Transform newEntry = Instantiate(entryBlank, listContainer);
        RectTransform entryRect = newEntry.GetComponent<RectTransform>();
        entryRect.anchoredPosition = new Vector2(0, -30 * transformList.Count);
        newEntry.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        newEntry.Find("PosText").GetComponent<Text>().text = rank.ToString();

        int score = data.playerPoints;
        newEntry.Find("PosScoreText").GetComponent<Text>().text = score.ToString();

        string name = data.playerName;
        newEntry.Find("PosNameText").GetComponent<Text>().text = name;

        transformList.Add(newEntry);
    }




}
