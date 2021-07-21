using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private Animator anim;
    public AudioClip[] DiamsSFX;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Taken", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("Taken", true);
            addDiamond(1);
            PlayRandomSound();
        }
    }

    void PlayRandomSound() 
    {
        int i = Random.Range(0, DiamsSFX.Length);

        AudioManager.Mine.sourceSFX.PlayOneShot(DiamsSFX[i]);
    }

    static public void addDiamond(int nbr)
    {
        Score.Mine.Diamonds += nbr;
        PlayerPrefs.SetInt("diamond", Score.Mine.Diamonds);
    }
}
