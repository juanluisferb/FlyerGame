using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Test class to try serializing a JSON file with a list of classes
[System.Serializable]
public class HighScores : MonoBehaviour
{
    public List<PlayerData> highscores;
}
