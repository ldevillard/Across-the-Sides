using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_Generator : MonoBehaviour
{
    static public Obstacles_Generator Mine;

    public float speed;
    public GameObject[] Moduls;
    public AudioClip speedUpgrade;

    


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
        speed = Obstacles_Manager.speed;

        RandomObstacles();
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted)
            transform.position = new Vector2(transform.position.x, Time.deltaTime * (-speed) + transform.position.y);
        speed = Obstacles_Manager.speed;
    }

    int RandomObstacles()
    {
        int i = 0;

        while (i < Moduls.Length)
            Moduls[i++].gameObject.SetActive(false);

        if (Score.Mine.score < 10)
            i = Random.Range(0, Moduls.Length / 4);
        else if (Score.Mine.score < 20)
            i = Random.Range(0, Moduls.Length / 2);
        else if (Score.Mine.score < 30)
            i = Random.Range(0, Moduls.Length / 4 * 3);
        else
            i = Random.Range(0, Moduls.Length);
        Moduls[i].gameObject.SetActive(true);
        Moduls[i].GetComponent<DiamondGenerator>().GenerateDiamond();
        return i;
    }
}
