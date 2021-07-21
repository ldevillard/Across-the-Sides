using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{

    public Text Score_text, BestScore_text;

    void Start()
    {
        Score_text.text = "" + Score.Mine.score;
        BestScore_text.text = "" + Score.Mine.bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
