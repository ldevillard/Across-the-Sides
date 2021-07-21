using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondGenerator : MonoBehaviour
{
    public GameObject Diamond;

    void Start()
    {
        GenerateDiamond();
    }

    public void GenerateDiamond()
    {
        int i = Random.Range(0, 2);

        if (i == 0)
            Diamond.gameObject.SetActive(true);
        else
            Diamond.gameObject.SetActive(false);
    }
}
