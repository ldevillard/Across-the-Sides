using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    int direction;
    float speed;
    private Animator anim;

    void Start()
    {
        direction = 0;
        speed = 15;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            GameManager.Mine.GameStarted = false;
            GameManager.Mine.ParticlePlayer.SetActive(true);
            gameObject.SetActive(false);
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        }
        else if (collision.tag == "Portal")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            anim.SetBool("StartTP", true);
        }
        else if (collision.tag == "Portal2")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            anim.SetBool("StartTP2", true);
        }
    }

    public void SwitchDistance()
    {
        direction = 1;
    }

    public void SwitchDistance2()
    {
        direction = 0;
    }

    public void ResetTP2()
    {
        anim.SetBool("StartTP2", false);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    public void ResetTP()
    {
        anim.SetBool("StartTP", false);
        GetComponent<CircleCollider2D>().enabled = true;
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

        if (direction == 0 && transform.position.x < 1.70f)
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, 1.72f, speed * Time.deltaTime), transform.position.y);
        else if (direction == 1 && transform.position.x > -1.70f)
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, -1.72f, speed * Time.deltaTime), transform.position.y);
    }
}
