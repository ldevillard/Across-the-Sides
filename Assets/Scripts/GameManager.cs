using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    static public GameManager Mine;

    public bool GameStarted;
    public GameObject Player;
    public GameObject ParticlePlayer;
    public GameObject Fade, Wipe;

    private Camera cam;
    public Text scoreText;

    void Start()
    {

        Mine = this;
        GameStarted = false;
        Player.gameObject.SetActive(false);
        ParticlePlayer.gameObject.SetActive(false);
        
        transform.position = new Vector3(0, 0, -10);
        if (DontDestroy.fade)
        {
            Fade.SetActive(true);
            Wipe.SetActive(false);
        }
        else 
        {
            Fade.SetActive(false);
            Wipe.SetActive(true);
        }

        /*cam = GetComponent<Camera>();
        if (Score.Mine.bestScore > 0) 
        {
            int i = RandomCam();
            if (PlayerPrefs.HasKey("camColor")) 
            {
                while (i == PlayerPrefs.GetInt("camColor"))
                    i = RandomCam();
            }
            PlayerPrefs.SetInt("camColor", i);
        }*/
    }


    int RandomCam() 
    {
        int i = Random.Range(0, 5);

        if (i == 0)
            cam.backgroundColor = new Color(1, 0.886f, 0.627f);
        else if (i == 1)
            cam.backgroundColor = new Color(0.827f, 0.933f, 1);
        else if (i == 2)
            cam.backgroundColor = new Color(0.965f, 0.824f, 1);
        return i;
    }
    //FFE2A0
    //323232
}
