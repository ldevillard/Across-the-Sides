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
    public AudioClip swipeSprite;
    public Text Price;

    public GameObject BuyObj;
    public GameObject PriceObj;
    public GameObject Select;

    public GameObject SelectedAnim;

    void Start()
    {
        Mine = this;

        if (PlayerPrefs.HasKey("sprite"))
        {
            Sprite.GetComponent<Image>().sprite = PlayerSkin.Mine.Skins[PlayerPrefs.GetInt("sprite")];
            idx = PlayerPrefs.GetInt("sprite");
        }
        else 
        {
            Sprite.GetComponent<Image>().sprite = PlayerSkin.Mine.Skins[0];
            idx = 0;
        }

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
            //Select.SetActive(true);
        }
        else
            PriceObj.SetActive(true);
    }

    public void QuitShop() 
    {
        //StartANim
        SceneManager.UnloadSceneAsync(3);
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

    public void Buy() 
    {
        Score.Mine.Diamonds -= PlayerSkin.Mine.Price[idx];
        PlayerPrefs.SetInt("diamond", Score.Mine.Diamonds);

        string item = "sprite" + idx;
        PlayerPrefs.SetInt(item, 1);

        BuyObj.SetActive(false);
        PriceObj.SetActive(false);
        //Select.SetActive(true);
   }
}
