using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_Generator : MonoBehaviour
{
    static public Obstacles_Generator Mine;

    public float speed;
    public GameObject[] Moduls;

    private int curScore = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 20);
            RandomObstacles();

            Score.Mine.score += 1;
            if (Score.Mine.bestScore < Score.Mine.score)
                Score.Mine.actuBestScore();
        }
    }

    void Start()
    {
        Mine = this;
        speed = 7f;

        RandomObstacles();
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted)
            transform.position = new Vector2(transform.position.x, Time.deltaTime * (-speed) + transform.position.y);
        if (curScore + 10 <= Score.Mine.score && Score.Mine.score <= 60)
        {
            UIManager.Mine.UpgradeText.gameObject.SetActive(true);
            curScore = Score.Mine.score;
            speed *= 1.1f;
        }
    }

    int RandomObstacles()
    {
        int i = 0;

        while (i < Moduls.Length)
            Moduls[i++].gameObject.SetActive(false);
        i = Random.Range(0, Moduls.Length);
        Moduls[i].gameObject.SetActive(true);
        return i;
    }
}
