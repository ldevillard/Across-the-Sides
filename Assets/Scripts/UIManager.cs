using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    static public UIManager Mine;

    public Text ScoreText;
    public GameObject UpgradeText;
    public Text Diamonds;

    public AudioClip openShop;

    private void Start()
    {
        Mine = this;
        ScoreText.gameObject.SetActive(false);

        UpgradeText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Mine.GameStarted)
        {
            ScoreText.gameObject.SetActive(true);
            ScoreText.text = "" + Score.Mine.score;
        }
        else
        {
            ScoreText.gameObject.SetActive(false);
        }

        Diamonds.text = "" + Score.Mine.Diamonds;
    }

    public void OpenShop() 
    {
        AudioManager.Mine.sourceSFX.PlayOneShot(openShop);
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
    }
}
