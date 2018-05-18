using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomArena : UnityEngine.MonoBehaviour
{
    private int rnd;

    public GameObject randomBlocks1;
    public GameObject randomBlocks2;
    public GameObject randomBlocks3;


    private int chooseRandomBlocks;

    private void Start()
    {
        rnd = Random.Range(1, 4);
        PlayerPrefs.SetInt("random", rnd);
        chooseRandomBlocks = PlayerPrefs.GetInt("random");
    }

    public void Update()
    {

        if (chooseRandomBlocks == 1)
        {
            randomBlocks1.SetActive(true);
        }
        if (chooseRandomBlocks == 2)
        {
            randomBlocks2.SetActive(true);
        }
        if (chooseRandomBlocks == 3)
        {
            randomBlocks3.SetActive(true);
        }
    }
}
