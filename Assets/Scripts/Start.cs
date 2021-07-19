using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public GameObject StartFold;

    public void StartButton()
    {
        StartFold.gameObject.SetActive(false);
        GameManager.Mine.GameStarted = true;
    }
}
