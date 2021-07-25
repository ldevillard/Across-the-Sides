using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Obstacles_Manager : MonoBehaviour
{
    static public float speed;
    private bool speedUpgraded;
    void Start()
    {
        speedUpgraded = false;

        speed = 6f;

        int i;

        if (Score.Mine.score <= 60)
            i = Score.Mine.score / 10;
        else
            i = 6;

        for (int j = 0; j < i; j++)
            speed *= 1.1f;

        if (Score.Mine.score >= 80)
            speed *= 1.1f;
        if (Score.Mine.score >= 100)
            speed *= 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.Mine.score % 10 == 0 && Score.Mine.score != 0 && Score.Mine.score <= 60 && GameManager.Mine.GameStarted && !speedUpgraded)
        {
            speedUpgraded = true;

            UIManager.Mine.UpgradeText.gameObject.SetActive(true);
            AudioManager.Mine.sourceSFX.PlayOneShot(Obstacles_Generator.Mine.speedUpgrade);

            int i = Score.Mine.score / 10;

            speed = 6;

            for (int j = 0; j < i; j++)
                speed *= 1.1f;
        }
        else if (Score.Mine.score % 20 == 0 && Score.Mine.score != 0 && Score.Mine.score <= 100 && GameManager.Mine.GameStarted && !speedUpgraded) 
        {
            speedUpgraded = true;

            UIManager.Mine.UpgradeText.gameObject.SetActive(true);
            AudioManager.Mine.sourceSFX.PlayOneShot(Obstacles_Generator.Mine.speedUpgrade);

            int i = 6;

            speed = 6;

            for (int j = 0; j < i; j++)
                speed *= 1.1f;

            if (Score.Mine.score >= 80)
                speed *= 1.1f;
            if (Score.Mine.score >= 100)
                speed *= 1.1f;
        }
        else if (Score.Mine.score % 10 != 0)
            speedUpgraded = false;
    }
}
