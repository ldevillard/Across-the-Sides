using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public GameObject ON, OFF;
    void Start()
    {
        if (PlayerPrefs.HasKey("sound"))
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                ON.SetActive(true);
                OFF.SetActive(false);
                AudioListener.volume = 1;
            }
            else
            {
                ON.SetActive(false);
                OFF.SetActive(true);
                AudioListener.volume = 0;
            }
        }
        else 
        {
            ON.SetActive(true);
            OFF.SetActive(false);
            AudioListener.volume = 1;
        }
    }

    public void ChangeAudio() 
    {
        if (ON.activeSelf)
        {
            ON.SetActive(false);
            OFF.SetActive(true);
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("sound", 0);
        }
        else 
        {
            ON.SetActive(true);
            OFF.SetActive(false);
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("sound", 1);
        }
    }
}
