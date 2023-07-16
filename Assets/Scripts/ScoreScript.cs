using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int PlayerScore;

    [SerializeField] TextMeshProUGUI textScore;

    public void AddScore(int score)
    {
       PlayerScore += score;
       textScore.text = "Score: " + PlayerScore.ToString();
    }
}
