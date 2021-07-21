using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Mine;

    public bool GameStarted;
    public GameObject Player;
    public GameObject ParticlePlayer;



    void Start()
    {
        Mine = this;
        GameStarted = false;
        Player.gameObject.SetActive(false);
        ParticlePlayer.gameObject.SetActive(false);
        transform.position = new Vector3(0, 0, -10);
    }

    void Update()
    {
       
    }
}
