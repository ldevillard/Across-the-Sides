using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public AudioSource audioSource;
    static public bool fade;
    static public bool RewardAdd;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fade = true;
        RewardAdd = true;
    }
}
