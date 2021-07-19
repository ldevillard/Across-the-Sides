using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Mine;

    public bool GameStarted;

    void Start()
    {
        Mine = this;
        GameStarted = false;
    }

    void Update()
    {
        
    }
}
