using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static public Score Mine;

    public int score, bestScore, Diamonds;

    private void Awake()
    {
        Mine = this;
        if (PlayerPrefs.HasKey("score")) 
        {
            score = PlayerPrefs.GetInt("score");
            PlayerPrefs.DeleteKey("score");
        }
        else
            score = 0;
        if (PlayerPrefs.HasKey("bestScore"))
            bestScore = PlayerPrefs.GetInt("bestScore");
        else
            bestScore = 0;

        if (PlayerPrefs.HasKey("diamond"))
            Diamonds = PlayerPrefs.GetInt("diamond");
        else
            Diamonds = 0;
    }

    public void actuBestScore()
    {
        bestScore = score;
        PlayerPrefs.SetInt("bestScore", bestScore);
    }
}
