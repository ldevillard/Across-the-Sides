using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted)
            transform.position = new Vector2(transform.position.x, Time.deltaTime * (-Obstacles_Manager.speed) + transform.position.y);
    }
}
