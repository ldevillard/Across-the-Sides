using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{

    public Text Score_text, BestScore_text;
    public GameObject Wipe;
    public AudioClip restart;

    void Start()
    {
        Score_text.text = "" + Score.Mine.score;
        BestScore_text.text = "" + Score.Mine.bestScore;
        Wipe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        AudioManager.Mine.sourceSFX.PlayOneShot(restart);
        DontDestroy.fade = false;
        Wipe.SetActive(true);
        Ads.Mine.ShowAds();
    }
}
