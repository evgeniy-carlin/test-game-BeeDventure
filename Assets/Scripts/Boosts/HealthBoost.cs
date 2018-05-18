using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public GameObject healthBoost;

    void Start()
    {
        if (PlayerPrefs.GetInt("randomBoost") == 2)
            {
            healthBoost.SetActive(true);
        }
    }
}
