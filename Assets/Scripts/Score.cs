using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static public Score Mine;

    public int score, bestScore;

    private void Start()
    {
        Mine = this;
        score = 0;
        if (PlayerPrefs.HasKey("bestScore"))
            bestScore = PlayerPrefs.GetInt("bestScore");
        else
            bestScore = 0;
    }

    public void actuBestScore()
    {
        bestScore = score;
        PlayerPrefs.SetInt("bestScore", bestScore);
    }
}
