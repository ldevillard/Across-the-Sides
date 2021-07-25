using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    static public Shop Mine;

    public Text Diamonds;
    public GameObject Sprite;
    int idx;
    public AudioClip swipeSprite, closeShop, buy, select;
    public Text Price;

    public GameObject BuyObj;
    public GameObject PriceObj;
    public GameObject Select;

    public GameObject SelectedAnim;
    public GameObject BuyAnim;

    public Animator Anim;

    void Start()
    {
        Mine = this;

        Anim.SetBool("close", false);

        int i = 0;
        bool keyFound = false;
        while (i < PlayerSkin.Mine.Skins.Length) 
        {
            if (PlayerPrefs.HasKey("sprite" + i))
            {
                Sprite.GetComponent<Image>().sprite = PlayerSkin.Mine.Skins[0];
                idx = 0;
                keyFound = true;
            }
            i++;
        }
        if (!keyFound) 
        {
            Sprite.GetComponent<Image>().sprite = PlayerSkin.Mine.Skins[0];
            PlayerPrefs.SetInt("sprite" + 0, 1);
            PlayerPrefs.SetInt("select" + 0, 1);
            idx = 0;
        }

        BuyAnim.SetActive(false);
        SelectedAnim.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Diamonds.text = "" + Score.Mine.Diamonds;
        Price.text = "" + PlayerSkin.Mine.Price[idx];

        if (Score.Mine.Diamonds >= PlayerSkin.Mine.Price[idx])
        {
            Price.color = new Color(0.392f, 1, 0.298f);
            BuyObj.SetActive(true);
        }
        else 
        {
            Price.color = new Color(1, 0.325f, 0.325f);
            BuyObj.SetActive(false);
        }

        if (PlayerPrefs.HasKey("sprite" + idx))
        {
            BuyObj.SetActive(false);
            PriceObj.SetActive(false);
            if (PlayerPrefs.HasKey("select" + idx))
                Select.SetActive(false);
            else
                Select.SetActive(true);
        }
        else 
        {
            PriceObj.SetActive(true);
            Select.SetActive(false);
        }

    }

    public void StartQuitingShop()
    {
        AudioManager.Mine.sourceSFX.PlayOneShot(closeShop);
        Anim.SetBool("close", true);
    }

    public void SpriteNext() 
    {
        idx++;

        if (idx == PlayerSkin.Mine.Skins.Length)
            idx = 0;

        AudioManager.Mine.sourceSFX.PlayOneShot(swipeSprite);

        Sprite.GetComponent<Image>().sprite = PlayerSkin.Mine.Skins[idx];
        Sprite.SetActive(false);
        Sprite.SetActive(true);
    }

    public void SpritePrev()
    {
        idx--;

        if (idx == -1)
            idx = PlayerSkin.Mine.Skins.Length - 1;

        AudioManager.Mine.sourceSFX.PlayOneShot(swipeSprite);

        Sprite.GetComponent<Image>().sprite = PlayerSkin.Mine.Skins[idx];
        Sprite.SetActive(false);
        Sprite.SetActive(true);
    }

    public void SelectSprite()
    {
        int i = 0;

        while (i < PlayerSkin.Mine.Skins.Length) 
        {
            if (PlayerPrefs.HasKey("select" + i))
                PlayerPrefs.DeleteKey("select" + i);
            i++;
        }
        PlayerPrefs.SetInt("select" + idx, 1);
        SelectedAnim.SetActive(true);
        AudioManager.Mine.sourceSFX.PlayOneShot(select);
    }

    public void Buy() 
    {
        Score.Mine.Diamonds -= PlayerSkin.Mine.Price[idx];
        PlayerPrefs.SetInt("diamond", Score.Mine.Diamonds);

        string item = "sprite" + idx;
        PlayerPrefs.SetInt(item, 1);

        BuyObj.SetActive(false);
        PriceObj.SetActive(false);
        Select.SetActive(true);

        BuyAnim.SetActive(true);
        AudioManager.Mine.sourceSFX.PlayOneShot(buy);
    }
}
