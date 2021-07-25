using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour, IUnityAdsListener
{

    static public Ads Mine;

#if UNITY_IOS
    private string gameId = "4227044";
#elif UNITY_ANDROID
    private string gameId = "4227045";
#endif

    bool testMode = false;
    string mySurfacingId = "rewardedVideo";
    int nbrAds;

    bool revive;

    void Awake()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    // Initialize the Ads service:
    void Start()
    {
        Mine = this;
        if (PlayerPrefs.HasKey("ads"))
            nbrAds = PlayerPrefs.GetInt("ads");
        else
            nbrAds = 0;
        revive = false;
    }

    public void ShowAds()
    {
        nbrAds++;
        if (nbrAds == 5) 
        {
            Advertisement.Show();
            nbrAds = 0;
        }
        PlayerPrefs.SetInt("ads", nbrAds);
    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            //Debug.Log("Rewarded ad shown");
            Advertisement.Show(mySurfacingId);
            revive = true;
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (revive) 
            {
                Lose.Mine.RestartWithReward();
                DontDestroy.RewardAdd = false;
                revive = false;
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

}