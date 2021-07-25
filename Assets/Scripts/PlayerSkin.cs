using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    static public PlayerSkin Mine;

    public Sprite[] Skins;
    public int[] Price;

    void Start()
    {
        Mine = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
