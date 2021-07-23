using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{

    static public Ads Mine;

#if UNITY_IOS
    private string gameId = "4227044";
#elif UNITY_ANDROID
    private string gameId = "4227045";
#endif

    bool testMode = false;
    int nbrAds;

    // Initialize the Ads service:
    void Start()
    {
        Mine = this;
        Advertisement.Initialize(gameId, testMode);
        if (PlayerPrefs.HasKey("ads"))
            nbrAds = PlayerPrefs.GetInt("ads");
        else
            nbrAds = 0;
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

}