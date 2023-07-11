using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;

    
    public void addScore(int score)
    {
       ScoreHandler.playerScore += score;
       textScore.text = "Score: " + ScoreHandler.playerScore.ToString();
    }
}
