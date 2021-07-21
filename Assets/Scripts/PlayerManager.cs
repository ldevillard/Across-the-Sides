using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    int direction;
    float speed;
    private Animator anim;
    public AudioClip pop, dead, portal, bar;

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
            EndGame();
        }
        else if (collision.tag == "Portal")
        {
            AudioManager.Mine.sourceSFX.PlayOneShot(portal);
            GetComponent<CircleCollider2D>().enabled = false;
            anim.SetBool("StartTP", true);
        }
        else if (collision.tag == "Portal2")
        {
            AudioManager.Mine.sourceSFX.PlayOneShot(portal);
            GetComponent<CircleCollider2D>().enabled = false;
            anim.SetBool("StartTP2", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bar")
            AudioManager.Mine.sourceSFX.PlayOneShot(bar);
    }

    public void EndGame() 
    {
        AudioManager.Mine.sourceSFX.PlayOneShot(dead);
        GameManager.Mine.GameStarted = false;
        GameManager.Mine.ParticlePlayer.SetActive(true);
        gameObject.SetActive(false);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
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
            AudioManager.Mine.sourceSFX.PlayOneShot(pop);
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
