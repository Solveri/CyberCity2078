using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;

    private int playerScore;

    public void addScore(int score)
    {
        playerScore += score;
        textScore.text = "Score: " + playerScore.ToString();
    }
}
