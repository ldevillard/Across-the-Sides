using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_Generator : MonoBehaviour
{
    static public Obstacles_Generator Mine;

    public float speed;
    public GameObject[] Moduls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 20);

            RandomObstacles();
        }
    }

    void Start()
    {
        Mine = this;
        speed = 8f;

        RandomObstacles();
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted)
            transform.position = new Vector2(transform.position.x, Time.deltaTime * (-speed) + transform.position.y);
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
