using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager Mine;
    
    public AudioSource sourceSFX;
    void Start()
    {
        Mine = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
