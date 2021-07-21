using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public GameObject StartFold, Buttons;
    public AudioClip startSFX;

    public void StartButton()
    {
        AudioManager.Mine.sourceSFX.PlayOneShot(startSFX);
        StartFold.gameObject.SetActive(false);
        GameManager.Mine.GameStarted = true;
        GameManager.Mine.Player.SetActive(true);
        Buttons.SetActive(false);
    }
}
