using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public GameObject CrossFade;

    private void Start()
    {
        LoadLevel(1);
    }
    public void LoadLevel(int sceneIdx) 
    {
        StartCoroutine(LoadAsynchronously(sceneIdx));
    }

    IEnumerator LoadAsynchronously(int sceneIndex) 
    {
        float i = 0;
        CrossFade.SetActive(false);

        while (i < 100)
        {
            progressText.text = i + "%";

            slider.value = i / 100;
            i += 2;
            yield return null;
        }
        CrossFade.SetActive(true);
    }
}
