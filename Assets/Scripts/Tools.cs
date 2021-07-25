using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tools : MonoBehaviour
{
    public void setObjectFalse()
    {
        gameObject.SetActive(false);
    }

    public void QuitShop()
    {
        //StartANim
        SceneManager.UnloadSceneAsync(3);
    }
}
