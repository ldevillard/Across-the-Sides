using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text ScoreText;

    private void Start()
    {
        ScoreText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted)
        {
            ScoreText.gameObject.SetActive(true);
            ScoreText.text = "" + Score.Mine.score;
        }
        else
        {
            ScoreText.gameObject.SetActive(false);
        }
    }
}
