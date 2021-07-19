using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    int direction;
    float speed;
    public GameObject Particles;

    void Start()
    {
        direction = 0;
        speed = 15;
        Particles.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            GameManager.Mine.GameStarted = false;
            Particles.gameObject.SetActive(true);
            gameObject.SetActive(false);
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Mine.GameStarted)
        {
            if (direction == 0)
                direction = 1;
            else
                direction = 0;
        }

        if (direction == 0 && transform.position.x < 1.62f)
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, 1.65f, speed * Time.deltaTime), transform.position.y);
        else if (direction == 1 && transform.position.x > -1.62f)
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, -1.65f, speed * Time.deltaTime), transform.position.y);
    }
}
