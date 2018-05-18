using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviour : UnityEngine.MonoBehaviour
{
    protected int chooseRandomBoost;

    private void Awake()
    {
        chooseRandomBoost = PlayerPrefs.GetInt("randomBoost");
    }


}
