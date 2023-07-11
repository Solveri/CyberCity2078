using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] static int playerScore;

    public void AddScore(int score)
    {
       playerScore += score;
       textScore.text = "Score: " + playerScore.ToString();
    }
}
