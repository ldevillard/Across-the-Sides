using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{

    static public Lose Mine;

    public Text Score_text, BestScore_text;
    public GameObject Wipe;
    public AudioClip restart;
    public GameObject RewardAd;


    void Start()
    {
        Mine = this;
        Score_text.text = "" + Score.Mine.score;
        BestScore_text.text = "" + Score.Mine.bestScore;
        if (DontDestroy.RewardAdd)
            RewardAd.SetActive(true);
        else
            RewardAd.SetActive(false);
        Wipe.SetActive(false);
    }

    // Update is called once per frame
    public void ShowRewardAd() 
    {
        Ads.Mine.ShowRewardedVideo();
    }
    public void RestartWithReward() 
    {
        PlayerPrefs.SetInt("score", Score.Mine.score);
        AudioManager.Mine.sourceSFX.PlayOneShot(restart);
        DontDestroy.fade = false;
        Wipe.SetActive(true);
    }

    public void RestartGame()
    {
        AudioManager.Mine.sourceSFX.PlayOneShot(restart);
        DontDestroy.fade = false;
        DontDestroy.RewardAdd = true;
        Wipe.SetActive(true);
        Ads.Mine.ShowAds();
    }
}
